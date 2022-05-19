using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartFormat;

namespace SmartFormat3SetupDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    public string Test()
    {
        var test = new
        {
            CreateDate = new DateTime(2022, 5, 22, 12, 7, 33),
            Name = "John",
            Street = "4th street"
        };

        var customFormatResult = CustomFormat.Format("{CreateDate:dd.MM.yyyy HH\\:mm} {Name} {Street:ismatch(th):TH|th}",
            test
        );
        Console.WriteLine(customFormatResult); // 22.05.2022 12:07 John 4th street

        try
        {
            var smartFormatResult = Smart.Format("{CreateDate:dd.MM.yyyy HH\\:mm {Name} {Street:ismatch(th):TH|th}",
                test
            ); // throws FormattingException: Error parsing format string: No formatter with name 'dd.MM.yyyy HH' found at 0 {CreateDate:dd.MM.yyyy HH:mm} {Name} {Street:ismatch(th):TH|th}

            return smartFormatResult;
        }
        catch (Exception e)
        {
            Console.WriteLine(JsonConvert.SerializeObject(e, new JsonSerializerSettings { Formatting = Formatting.Indented, ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            throw;
        }
    }
}