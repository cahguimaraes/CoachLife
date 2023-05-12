using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoachLife.Application.Extensions.FluentResult
{
    public static class ResultExtensions
    {
        public static ActionResult ToActionResult<T>(this Result<T> result, HttpStatusCode statusCode, IAspNetCoreResultEndpointProfile profile)
        {
            return new ResultToActionResultTransformer().Transform(result, statusCode, profile);
        }

        public static ActionResult ToActionResult<T>(this Result<T> result, HttpStatusCode statusCode)
        {
            return result.ToActionResult(statusCode, AspNetCoreResult.Settings.DefaultProfile);
        }
    }
}