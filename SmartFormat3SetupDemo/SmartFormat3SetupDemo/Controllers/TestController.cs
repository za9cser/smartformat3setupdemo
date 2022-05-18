using Microsoft.AspNetCore.Mvc;
using SmartFormat;

namespace SmartFormat3SetupDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public string Test()
        {
            var str = Smart.Format("{CreateDate:dd.MM.yyyy HH:mm} {Name} {Street:ismatch(th):TH|th}",
                new
                {
                    CreateDate = new DateTime(2022, 5, 22, 12, 7, 33),
                    Name = "John",
                    Street = "4th street"
                }
            );

            // get an exception insted of emty string

            return str;
        }
    }
}