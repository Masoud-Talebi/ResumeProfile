namespace ResumeProfile.Application.Common.Behaviros;

public class InputSanitizationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var stringProperties = request
            .GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType == typeof(string));

        foreach (var prop in stringProperties)
        {
            var value = prop.GetValue(request) as string;
            if (string.IsNullOrWhiteSpace(value)) continue;

            if (IsPotentiallyMalicious(value))
                throw new Exception("ورودی نامعتبر است.");
        }

        return await next();
    }

    private static bool IsPotentiallyMalicious(string input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        // 🧩 Normalize / Decode
        string normalized = input;
        try { normalized = Uri.UnescapeDataString(normalized); } catch { }
        normalized = WebUtility.HtmlDecode(normalized);
        normalized = normalized.Normalize(System.Text.NormalizationForm.FormC);
        normalized = Regex.Replace(normalized, @"\s+", " ").Trim();

        // 🧠 الگوهای خطرناک (updated 2025)
        var patterns = new[]
        {
        // 🕸 XSS
        @"<\s*script\b",                       // <script> یا هر نوع آن
        @"on\w+\s*=",                          // onclick=, onerror=, ...
        @"javascript\s*:",                     // javascript:
        @"data\s*:\s*text\/html",              // data:text/html
        @"expression\s*\(",                    // CSS expression()
        @"url\s*\(\s*['""]?\s*javascript\s*:", // CSS url("javascript:")
        @"<\s*(iframe|object|embed|meta|link|base|form)\b", // تگ‌های خطرناک
        @"document\.(cookie|location|write)",  // JS sink functions
        @"window\.location",                   // redirect ها
        @"innerHTML|outerHTML|insertAdjacentHTML",
        @"eval\s*\(",                          // eval(...)
        @"new\s+Function\s*\(",                // new Function(...)
        @"exec\s*\(",                          // exec(...)
        // 🧨 Command Injection
        @"[`$]\(",                             // $(), `cmd`
        @"[;|&]{1,2}",                         // ; , && , ||
        @"\b(rm|chmod|chown|curl|wget|sudo|bash|sh|powershell|cmd|copy|move|del)\b",
    };

        return patterns.Any(p =>
            Regex.IsMatch(normalized, p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled)
        );
    }
}
