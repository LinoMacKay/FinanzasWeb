using Microsoft.AspNetCore.Mvc;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController
    {

        [HttpGet]
        public string Index()
        {
            return "Running...";
        }
    }
}
