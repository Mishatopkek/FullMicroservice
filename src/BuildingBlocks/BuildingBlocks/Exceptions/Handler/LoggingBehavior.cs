using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Exceptions.Handler;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "[START] Handle request={RequestName} - Response={ResponseName} - RequestData={RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);

        Stopwatch timer = Stopwatch.StartNew();

        TResponse response = await next();

        timer.Stop();
        TimeSpan takenTime = timer.Elapsed;
        if (takenTime.Seconds > 3)
            logger.LogWarning("[PERFORMANCE] The request {Request} took {TakenTime}",
                typeof(TRequest).Name, takenTime.Seconds);
        logger.LogInformation("[END] Handled {Request} with {Response}",
            typeof(TRequest), typeof(TResponse));
        return response;
    }
}