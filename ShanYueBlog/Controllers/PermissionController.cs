using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Table.Authorize;
using Model.ViewModel;
using Services;
using ShanYue.Context;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class PermissionController : ControllerBase
    {
        private readonly IBaseService<Permission> baseService;

        public PermissionController(IBaseService<Permission> baseService)
        {
            this.baseService = baseService;
        }

        [HttpGet]
        public async Task<ResponseResult<PageViewModel<Permission>>> Get(int currentPage = 1, int pageSize = 10)
        {
            return ResponseResult<PageViewModel<Permission>>.Success(await baseService.QueryPage(currentPage, pageSize), "查询成功!");
        }

        [HttpPost]
        public async Task<ResponseResult<int>> Add(Permission model)
        {

            return ResponseResult<int>.Success(await baseService.Add(model), "添加成功!");
        }

        [HttpPut]
        public async Task<ResponseResult<int>> Update(Permission model)
        {
            return ResponseResult<int>.Success(await baseService.Update(model), "修改成功!");
        }

        [HttpDelete]
        public async Task<ResponseResult<long>> Delete(long id)
        {
            int v = await baseService.DeleteById(id);
            return v > 0 ? ResponseResult<long>.Success(id, "删除成功") : ResponseResult<long>.Failed();
        }

        [HttpGet]
        public async Task<ResponseResult<Permission>> GetDetail(long id)
        {

            Permission? permission = await baseService.QueryByIdAsNoTracking(id);
            return permission is not null ? ResponseResult.Success(permission, "查询成功!")
                : ResponseResult.Failed<Permission>(400, $"不存在id为{id}的实体!");
        }
    }
}
