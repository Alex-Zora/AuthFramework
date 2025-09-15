using Model.ViewModel;
using StackExchange.Redis;
using System.Text.Json;
using Role = Model.Table.Authorize.Role;

namespace ShanYue.Cache
{
    public class PermissionCache
    {
        /// <summary>
        /// 查询是否有所有角色权限的缓存 没有则缓存
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async static Task AllRolePermissionCache(IDatabase db, List<Role> roles)
        {
            //List<Role> roles = await context.Role.Include(x => x.RolePermissions).ThenInclude(y => y.permission).ToListAsync();
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

                    await db.HashSetAsync("Role_Permission", role.Id.ToString() + "-" + role.Name, jsonValue);
                }
            }            
        }

        /// <summary>
        /// 获取所有的角色对应权限
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async static Task<Dictionary<string, List<PermissionItem>>> GetAllRolePerssionCacheAsync(IDatabase db)
        {
            if(!await db.KeyExistsAsync("Role_Permission"))
            {
                throw new Exception("角色权限不存在, 请检查缓存");
            }
            HashEntry[] hashEntries = await db.HashGetAllAsync("Role_Permission");
            Dictionary<string, List<PermissionItem>> dictionary = new Dictionary<string, List<PermissionItem>>();
            foreach (var hashEntry in hashEntries)
            {
                var permissionItem = JsonSerializer.Deserialize<List<PermissionItem>>(hashEntry.Value!);
                dictionary.Add(hashEntry.Name!, permissionItem!);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取某个角色权限
        /// </summary>
        /// <returns></returns>
        public async static Task<List<PermissionItem>> GetRolePerssionCacheAsync(IDatabase db, string RoleId = "", string RoleName = "")
        {
            bool v = await db.HashExistsAsync("Role_Permission", RoleId);
            Dictionary<string, List<PermissionItem>> dictionary = await GetAllRolePerssionCacheAsync(db);
            List<PermissionItem> list = new List<PermissionItem>();
            foreach (var hashEntry in dictionary)
            {
                if(hashEntry.Key.Contains(RoleId + "-" + RoleName))
                {
                    list = hashEntry.Value;
                }
            }
            return list; 
        }

        /// <summary>
        /// 移除缓存中所有的角色权限
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public async static Task<bool> DeleteCacheAsync(IDatabase db)
        {
            bool v = await db.KeyExistsAsync("Role_Permission");
            if(!v)
            {
                return await db.KeyDeleteAsync("Role_Permission");
            }
            return false;
        }
    }
}
