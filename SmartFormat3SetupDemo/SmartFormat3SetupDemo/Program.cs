using System.Text.RegularExpressions;
using SmartFormat;
using SmartFormat.Core.Settings;
using SmartFormat.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

Smart.Default.Settings.FormatErrorAction = ErrorAction.Ignore;
Smart.Default.Settings.ParseErrorAction = ErrorAction.Ignore;

Smart.Default.AddExtensions(new IsMatchFormatter { RegexOptions = RegexOptions.CultureInvariant });

var test = new
{
    CreateDate = new DateTime(2022, 5, 22, 12, 7, 33),
    Name = "John",
    Street = "4th street"
};

var str = Smart.Format("{CreateDate:dd.MM.yyyy HH:mm} {Name} {Street:ismatch(th):TH|th}", test);
//  22.05.2022 12:07 John 4th street

Console.WriteLine(str);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();