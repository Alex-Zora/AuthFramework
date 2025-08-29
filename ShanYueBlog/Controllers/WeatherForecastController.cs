using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShanYue.Context;
using ShanYue.Model;
using ShanYue.Model.Authorize;

namespace ShanYue.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly BlogContext blogContext;
        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger, BlogContext blogContext)
        {
            _logger = logger;
            this.blogContext = blogContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "test")]
        public async Task<string> Test()
        {
            User user = GenarateUser();
            blogContext.User.Add(user);
            int v = await blogContext.SaveChangesAsync();
            return v.ToString();
        }

        [HttpPut]
        public async Task<string> TestPut()
        {
            User? user = await blogContext.User.Where(x => x.Id == 3).FirstOrDefaultAsync();
            int v = 0;
            if (user != null)
            {
                user.NickName = "ÕÅÈý";
                user.Password = "123456";
                blogContext.User.Update(user);
                v = blogContext.SaveChanges();
            }
            
            return v.ToString();
        }

        [HttpGet]
        public async Task<User> TestGet()
        {
            List<User> users = await blogContext.User.Where(x => x.Id < 10).ToListAsync();
            return users.FirstOrDefault();
        }

        private User GenarateUser()
        {
            string charString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            User user = new User();
            Random random = new Random();
            int rollNumber1 = random.Next(4,8);
            for(int i = 0; i <= rollNumber1; i++)
            {
                int rollNumber2 = random.Next(0, 27);
                user.Name += charString[rollNumber2];
            }

            rollNumber1 = random.Next(3, 8);
            for (int i = 0; i <= rollNumber1; i++)
            {
                int rollNumber2 = random.Next(0, 27);
                user.NickName += charString[rollNumber2];
            }

            rollNumber1 = random.Next(3, 8);
            for (int i = 0; i <= rollNumber1; i++)
            {
                int rollNumber2 = random.Next(0, 27);
                user.Password += charString[rollNumber2];
            }

            return user;
        }
    }
}
