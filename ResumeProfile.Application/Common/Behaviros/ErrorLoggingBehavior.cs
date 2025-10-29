using MediatR;
using Microsoft.AspNetCore.Http;
using ResumeProfile.Application.Common.Dtos;
using ResumeProfile.Application.Common.Interface;
using ResumeProfile.FrameWork.Common;

namespace ResumeProfile.Application.Common.Behaviros;

public class ErrorLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IErrorLogger _logger;
    private readonly IHttpContextAccessor _contextAccessor;
    public ErrorLoggingBehavior(IErrorLogger logger, IHttpContextAccessor contextAccessor)
    {
        _logger = logger;
        _contextAccessor = contextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();

        }
        catch (Exception ex)
        {
            var commandName = typeof(TRequest).Name;

            var userId = _contextAccessor?.HttpContext?.GetUserInformation().Item1;
            var userIP = _contextAccessor?.HttpContext?.GetUserInformation().Item2;

            // ذخیره خطا در جدول ErrorHistory
            var errorCode = await _logger.LogAsync(ex, commandName, userId, userIP, request);

            // اگر خروجی OkApiResult<T> باشه، Fail رو بساز
            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(OkApiResult<>))
            {
                var dataType = typeof(TResponse).GetGenericArguments()[0];
                var failMethod = typeof(OkApiResult<>)
                    .MakeGenericType(dataType)
                    .GetMethod("Fail", new[] { dataType, typeof(int) });

                object errorValue = dataType == typeof(string) ? ex.Message : Activator.CreateInstance(dataType);

                var failResult = failMethod.Invoke(null, new[] { errorValue, errorCode });
                return (TResponse)failResult;
            }

            // اگه ساختار Response متفاوت باشه، میشه Exception رو دوباره پرتاب کرد
            throw;
        }
    }
}