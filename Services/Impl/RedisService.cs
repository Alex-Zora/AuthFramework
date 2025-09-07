using Common.Cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Interface;
using ShanYue.Context;
using ShanYue.Model.ViewModel;
using StackExchange.Redis;
using System.Text.Json;

namespace Services.Impl
{
    public class RedisService: IRedisService
    {
        private readonly IDatabase _database;
        private readonly BlogContext blogContext;

        public RedisService(IConnectionMultiplexer connection, BlogContext blogContext)
        {
            this._database = connection.GetDatabase();
            this.blogContext = blogContext;
        }

        public async Task<bool> CacheAllRolePermissionAsync()
        {
            List<ShanYue.Model.Role> roles = blogContext.Role.Include(x => x.RolePermissions).ToList();
            if (roles.Count > 0)
            {
                //Dictionary<string, List<PermissionItem>> allRolePerm = new();
                foreach (var role in roles)
                {
                    List<PermissionItem> permissionItems = new();
                    foreach (var perm in role.RolePermissions)
                    {
                        permissionItems.Add(new PermissionItem { Name = perm.permission.Name, Url = perm.permission.Url });
                    }
                    //allRolePerm.Add(role.Id.ToString(), permissionItems);

                    string jsonValue = JsonSerializer.Serialize(permissionItems);

                    bool v = await _database.HashSetAsync("Role_Permission", role.Id.ToString() + "-" + role.Name, jsonValue);
                    return v;
                }
            }
            return false;
        }

        public async Task<Dictionary<string, List<PermissionItem>>> GetAllRolePermissionAsync()
        {
            Dictionary<string, List<PermissionItem>> dictionary = new Dictionary<string, List<PermissionItem>>();
            if (await _database.KeyExistsAsync("Role_Permission"))
            {
                HashEntry[] hashEntries = await _database.HashGetAllAsync("Role_Permission");
                foreach (var item in hashEntries)
                {
                    dictionary.Add(item.Name!, JsonSerializer.Deserialize<List<PermissionItem>>(item.Value!)!);
                }
            }

            return dictionary;
        }

        public async Task<List<PermissionItem>> GetRolePermissionAsync(long roleId)
        {
            List<PermissionItem> permissionItems = new List<PermissionItem>();
            Dictionary<string, List<PermissionItem>> dictionary = await GetAllRolePermissionAsync();
            foreach (var item in dictionary)
            {
                if(item.Key.Contains(roleId.ToString()))
                {
                    return item.Value;
                }
            }
            return permissionItems;
        }

        public async Task<List<T>> GetListAsync<T>(string key = "", int start = 0, int end = -1) where T : class
        {
            List<T> list = new List<T>();
            if(key.IsNullOrEmpty())
            {
                RedisValue[] redisValues = await _database.ListRangeAsync(key, start, end);
                list = redisValues.Select(x => JsonSerializer.Deserialize<T>(x!)).ToList()!;
            }
            return list;
        }

        public async Task<T> GetListElementAsync<T>(string key, Func<T, bool> func) where T : class, new()
        {
            T t = new T();
            if(await _database.KeyExistsAsync(key))
            {
                RedisValue[] redisValues = await _database.ListRangeAsync(key);
                foreach (var item in redisValues)
                {
                    T? entity = JsonSerializer.Deserialize<T>(item!);
                    if(entity != null && func(entity))
                    {
                        t = entity; break;
                    }
                }
            }
            return t;
        }

        public async Task<bool> RemoveListElementAsync<T>(string key,  Func<T, bool> func) where T : class
        {
            if(await _database.KeyExistsAsync(key))
            {
                RedisValue[] redisValues = await _database.ListRangeAsync(key, 0, -1);
                foreach (var item in redisValues)
                {
                    T? entity = JsonSerializer.Deserialize<T>(item!);
                    if (entity != null && func(entity))
                    {
                        await _database.ListRemoveAsync(key, item);
                        return true;
                    }
                }
            }
            
            return false;
        }

        public async Task<long> SetListElementAsync<T>(string key, T element)
        {
            return await _database.ListRightPushAsync(key, JsonSerializer.Serialize(element));
        }
    }
}
