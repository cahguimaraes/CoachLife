using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CoachLife.Application.Extensions.FluentResult
{
    public interface IAspNetCoreResultEndpointProfile
    {
        ActionResult TransformFailedResultToActionResult(FailedResultToActionResultTransformationContext context);

        ActionResult TransformOkNoValueResultToActionResult(OkResultToActionResultTransformationContext<Result> context);

        ActionResult TransformOkValueResultToActionResult<T>(OkResultToActionResultTransformationContext<Result<T>> context);
    }
}