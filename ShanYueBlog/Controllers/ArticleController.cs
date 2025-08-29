using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShanYue.Context;
using ShanYue.Model;

namespace ShanYue.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize("RBAC")]
    public class ArticleController : ControllerBase
    {
        private readonly BlogContext blogContext;
        public ArticleController(BlogContext blogContext) 
        {
            this.blogContext = blogContext;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return "获取文章列表";
        }

        [HttpPost]
        public async Task<string> Add()
        {
            Article article = new Article { Title = "测试文章", Content="内容", Type = 1};
            blogContext.Articles.Add(article);
            int v = await blogContext.SaveChangesAsync();
            return $"发布{v}文章";
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
