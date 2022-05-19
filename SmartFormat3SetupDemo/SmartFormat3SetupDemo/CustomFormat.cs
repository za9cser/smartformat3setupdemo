using System.Text.RegularExpressions;
using SmartFormat;
using SmartFormat.Core.Settings;
using SmartFormat.Extensions;

namespace SmartFormat3SetupDemo;

public static class CustomFormat
{
    private static readonly SmartFormatter _formatter = CreateCustomFormatter();

    private static SmartFormatter CreateCustomFormatter()
    {
        var formatter = Smart.CreateDefaultSmartFormat(new SmartSettings
        {
            Formatter = new FormatterSettings { ErrorAction = FormatErrorAction.Ignore },
            Parser = new ParserSettings { ErrorAction = ParseErrorAction.Ignore }
        });

        formatter.Settings.StringFormatCompatibility = true;
        formatter.AddExtensions(new TimeFormatter());
        formatter.AddExtensions(new IsMatchFormatter { RegexOptions = RegexOptions.CultureInvariant });
        return formatter;
    }

    public static string Format(string format, params object?[] args) => _formatter.Format(format, args);
}