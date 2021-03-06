using System;
using System.Net;
using Convey.WebApi.Exceptions;
using Pacco.Services.Deliveries.Application.Exceptions;
using Pacco.Services.Deliveries.Core.Exceptions;

namespace Pacco.Services.Deliveries.Infrastructure.Exceptions
{
    internal sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                DomainException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message},
                    HttpStatusCode.BadRequest),
                AppException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message},
                    HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new {code = "error", reason = "There was an error."},
                    HttpStatusCode.BadRequest)
            };
    }
}