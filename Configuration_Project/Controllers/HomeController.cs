using Microsoft.AspNetCore.Mvc;

namespace Configuration_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //GET: Loads configurations values into a new Options object
            WeatherApiOptions options = _configuration.GetSection("weatherapi").
                Get<WeatherApiOptions>();
            //Bind: Loads configurations values into existing Options object
            WeatherApiOptions options2 = new WeatherApiOptions();
            _configuration.GetSection("weatherapi").Bind(options);
            //Both configurations in that way are the same

            ViewBag.ClientID = options.ClientID;
            /*ViewBag.ClientIDb = options2.ClientID;*/

            ViewBag.ClientSecret = options.ClientSecret;
/*            ViewBag.ClientSecretb = options.ClientSecret;*/


            return View();
        }
    }
}
