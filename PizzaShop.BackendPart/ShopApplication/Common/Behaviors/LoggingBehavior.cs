using MediatR;
using Serilog;
using ShopApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        ICurrentUserService _currentUserService;

        public LoggingBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;
            Log.Information("Orders request: {Name} {@UserId} {@Request}",
                requestName, userId, request);//@(this) operator tell the Serialog that it must serialize object
                                              //instead of convert it to string by using (ToString() method)

            var response = await next();

            return response;
        }
    }
}
