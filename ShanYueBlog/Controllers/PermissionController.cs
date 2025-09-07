using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using ShanYue.Context;
using ShanYue.Model;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class PermissionController : ControllerBase
    {
        private readonly BlogContext blogContext;
        public PermissionController(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        //[HttpGet]
        //public async Task<ResponseResult<PageViewModel<Permission>>> Get(int currentPage = 1, int pageSize = 10)
        //{
        //}
    }
}
