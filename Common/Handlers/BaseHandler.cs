using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Responses;
using MediatR;
using NLog;

namespace Common.Handlers
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : BaseResponse, new ()
    {
        public abstract Task<TResponse> Execute(TRequest request);
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
//            BusinessValidationResult validationResult = await ExecuteBusinessValidator(request);
//            TResponse response = await Execute(request);
            Task<TResponse> response;
            
//            if (validationResult.IsValid)
//            {
                try
                {
                    response = Execute(request);
                }
                catch (Exception exception)
                {
//                    Logger.Error(exception);
                    response = null;
                }
//            }
//            else
//            {
//                response = GetErrorResponse(request, validationResult);
//            }

            return await response;
        }
    }
}