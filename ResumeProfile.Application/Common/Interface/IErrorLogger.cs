namespace ResumeProfile.Application.Common.Interface;
public interface IErrorLogger
{
    Task<string> LogAsync(Exception ex, string? commandName = null, long? userId = null, string? userIP = null, object? extraData = null);
}