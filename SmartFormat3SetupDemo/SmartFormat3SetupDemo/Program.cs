using System.Text.RegularExpressions;
using SmartFormat;
using SmartFormat.Core.Settings;
using SmartFormat.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

Smart.Default = Smart.CreateDefaultSmartFormat(new SmartSettings
{
    Formatter = new FormatterSettings { ErrorAction = FormatErrorAction.Ignore },
    Parser = new ParserSettings { ErrorAction = ParseErrorAction.Ignore }
});

// вырубаем форматтеры даты м времени от SmartFormat, чтобы работали стандартные .net форматтеры
Smart.Default.AddExtensions(new TimeFormatter());
Smart.Default.GetFormatterExtension<IsMatchFormatter>().RegexOptions = RegexOptions.CultureInvariant;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();