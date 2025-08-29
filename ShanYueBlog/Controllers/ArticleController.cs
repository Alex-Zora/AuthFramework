using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShanYue.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize("RBAC")]
    public class ArticleController : ControllerBase
    {
        public ArticleController() { }

        [HttpGet]
        public async Task<string> Get()
        {
            return "获取文章列表";
        }

        [HttpPost]
        public async Task<string> Add()
        {
            return "发布文章";
        }

        [HttpDelete]
        public async Task<string> Delete()
        {
            return "删除文章";
        }

        [HttpPut]
        public async Task<string> Update()
        {
            return "修改文章";
        }

        [HttpGet]
        public async Task<string> GetDetail()
        {
            return "文章详情";
        }
    }
}
