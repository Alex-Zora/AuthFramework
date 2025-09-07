using ShanYue.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IRedisService
    {
        /// <summary>
        /// 缓存所有的角色对应的权限
        /// </summary>
        /// <returns></returns>
        Task<bool> CacheAllRolePermissionAsync();

        /// <summary>
        /// 获取所有角色所有的权限
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, List<PermissionItem>>> GetAllRolePermissionAsync();

        /// <summary>
        /// 获取指定角色所有的权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<PermissionItem>> GetRolePermissionAsync(long roleId);

        /// <summary>
        /// 获取某个List的值 不传值则获取所有
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Task<List<T>> GetListAsync<T>(string key, int start = 0, int end = 1) where T : class;

        /// <summary>
        /// 获取List中符合条件的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<T> GetListElementAsync<T>(string key, Func<T, bool> func) where T : class, new();

        Task<long> SetListElementAsync<T>(string key, T element);
        /// <summary>
        /// 删除List中符合条件的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<bool> RemoveListElementAsync<T>(string key, Func<T, bool> func) where T:class;
    }
}
