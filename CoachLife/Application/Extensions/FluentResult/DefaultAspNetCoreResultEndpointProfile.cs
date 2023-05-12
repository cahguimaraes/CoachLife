using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CoachLife.Application.Extensions.FluentResult
{
    public class DefaultAspNetCoreResultEndpointProfile : IAspNetCoreResultEndpointProfile
    {
        public virtual ActionResult TransformFailedResultToActionResult(FailedResultToActionResultTransformationContext context)
        {
            var result = context.Result;

            var resultado = new ObjectResult(null);
            resultado.StatusCode = (int)context.StatusCode;

            resultado.Value = result.Errors.Select(e => new ErrorDto
            {
                Message = e.Message
            });

            return resultado;
        }

        public virtual ActionResult TransformOkNoValueResultToActionResult(OkResultToActionResultTransformationContext<Result> context)
        {
            return new OkResult();
        }

        public virtual ActionResult TransformOkValueResultToActionResult<T>(OkResultToActionResultTransformationContext<Result<T>> context)
        {
            var result = context.Result;

            var objectResult = new OkObjectResult(result.ValueOrDefault);
            objectResult.StatusCode = (int)context.StatusCode;
            return objectResult;
        }
    }
}