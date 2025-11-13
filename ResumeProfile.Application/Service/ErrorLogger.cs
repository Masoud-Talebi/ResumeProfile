namespace ResumeProfile.Application.Service;

public class ErrorLogger : IErrorLogger
{
    private readonly ILogDbContext _logContext;

    public ErrorLogger(ILogDbContext logContext)
    {
        _logContext = logContext;
    }

    public async Task<string> LogAsync(Exception ex, string? commandName = null, long? userId = null, string? userIP = null, object? extraData = null)
    {
        var errorCode = GenerateCode(6); //Guid.NewGuid().ToString().Substring(0, 8); // کدی کوتاه که به کاربر نمایش داده بشه

        if (await _logContext.ErrorHistories.AnyAsync(x => x.ErrorCode == errorCode))
            errorCode = GenerateCode(6);

        var error = new ErrorHistory
        {
            ErrorCode = errorCode,
            Message = ex.Message,
            StackTrace = ex.StackTrace,
            CommandName = commandName,
            CreatedByUserId = userId,
            ExtraData = extraData != null ? System.Text.Json.JsonSerializer.Serialize(extraData) : null
        };

        _logContext.ErrorHistories.Add(error);
        await _logContext.SaveChangesAsync();

        return errorCode; // این کد به سمت کاربر برگردونده میشه
    }

    private static string GenerateCode(int length)
    {
        const string chars = "1234567890"; // بدون حروف/اعداد مشابه (I, O, 0, 1)
        var sb = new StringBuilder(length);
        using var rng = RandomNumberGenerator.Create();
        var buf = new byte[4];

        for (int i = 0; i < length; i++)
        {
            rng.GetBytes(buf);
            uint r = BitConverter.ToUInt32(buf, 0);
            sb.Append(chars[(int)(r % (uint)chars.Length)]);
        }

        return sb.ToString();
    }

}