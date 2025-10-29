using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ResumeProfile.Application.Common.Extensions;

public static class StringExtensions
{
    public static string ToEnglishNumbers(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        var persian = new[] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
        var arabic = new[] { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };

        for (int i = 0; i < 10; i++)
        {
            input = input.Replace(persian[i], (char)('0' + i));
            input = input.Replace(arabic[i], (char)('0' + i));
        }

        return input;
    }

    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()?
                        .Name ?? enumValue.ToString();
    }
    
    public static bool IsPersian(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        // چک کردن وجود حداقل یک کاراکتر فارسی
        return Regex.IsMatch(input, @"[\u0600-\u06FF\u0750-\u077F\u08A0-\u08FF\uFB50-\uFDFF\uFE70-\uFEFF]");
    }
}