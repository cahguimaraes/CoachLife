using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoachLife.Application.Extensions.FluentResult
{
    public class FailedResultToActionResultTransformationContext
    {
        public ResultBase Result { get; }
        public HttpStatusCode StatusCode { get; }

        public FailedResultToActionResultTransformationContext(ResultBase result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }
    }

    public class OkResultToActionResultTransformationContext<TResult>
        where TResult : ResultBase
    {
        public TResult Result { get; }
        public HttpStatusCode StatusCode { get; }

        public OkResultToActionResultTransformationContext(TResult result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }
    }

    public interface IErrorDto
    {
        string Message { get; set; }
    }

    public class ErrorDto : IErrorDto
    {
        public string Message { get; set; }
    }

    public class ResultToActionResultTransformer
    {
        public ActionResult Transform(Result result, HttpStatusCode? statusCode, IAspNetCoreResultEndpointProfile profile)
        {
            if (result.IsFailed)
            {
                return profile.TransformFailedResultToActionResult(new FailedResultToActionResultTransformationContext(result, statusCode.GetValueOrDefault()));
            }

            return profile.TransformOkNoValueResultToActionResult(new OkResultToActionResultTransformationContext<Result>(result, statusCode.GetValueOrDefault()));
        }

        public ActionResult Transform<T>(Result<T> result, HttpStatusCode? statusCode, IAspNetCoreResultEndpointProfile profile)
        {
            if (result.IsFailed)
            {
                return profile.TransformFailedResultToActionResult(new FailedResultToActionResultTransformationContext(result, statusCode.GetValueOrDefault()));
            }

            return profile.TransformOkValueResultToActionResult(new OkResultToActionResultTransformationContext<Result<T>>(result, statusCode.GetValueOrDefault()));
        }
    }
}
