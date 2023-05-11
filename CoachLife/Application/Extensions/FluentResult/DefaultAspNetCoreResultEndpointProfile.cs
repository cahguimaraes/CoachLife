using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CoachLife.Application.Extensions.FluentResult
{
    public class DefaultAspNetCoreResultEndpointProfile : IAspNetCoreResultEndpointProfile
    {
        public virtual ActionResult TransformFailedResultToActionResult(FailedResultToActionResultTransformationContext context)
        {
            var result = context.Result;

            var errorDtos = result.Errors.Select(e => new HttpResponseMessage
            {
                ReasonPhrase = e.Message,
                StatusCode = context.StatusCode
            });

            return new NotFoundObjectResult(errorDtos);
        }

        public virtual ActionResult TransformOkNoValueResultToActionResult(OkResultToActionResultTransformationContext<Result> context)
        {
            return new OkResult();
        }

        public virtual ActionResult TransformOkValueResultToActionResult<T>(OkResultToActionResultTransformationContext<Result<T>> context)
        {
            return new OkObjectResult(context.Result.ValueOrDefault);
        }
    }
}