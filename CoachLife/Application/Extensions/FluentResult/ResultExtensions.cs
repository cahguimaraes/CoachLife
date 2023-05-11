using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoachLife.Application.Extensions.FluentResult
{
    public static class ResultExtensions
    {
        public static ActionResult ToActionResult(this Result result, IAspNetCoreResultEndpointProfile profile)
        {
            return new ResultToActionResultTransformer().Transform(result, null, profile);
        }
        public static async Task<ActionResult> ToActionResult(this Task<Result> resultTask, IAspNetCoreResultEndpointProfile profile)
        {
            var result = await resultTask;
            return new ResultToActionResultTransformer().Transform(result, null, profile);
        }

        public static ActionResult ToActionResult(this Result result)
        {
            return result.ToActionResult(AspNetCoreResult.Settings.DefaultProfile);
        }

        public static async Task<ActionResult> ToActionResult(this Task<Result> resultTask)
        {
            var result = await resultTask;
            return result.ToActionResult(AspNetCoreResult.Settings.DefaultProfile);
        }

        public static ActionResult ToActionResultAndStatusCode<T>(this Result<T> result, HttpStatusCode statusCode, IAspNetCoreResultEndpointProfile profile)
        {
            return new ResultToActionResultTransformer().Transform(result, statusCode, profile);
        }

        public static ActionResult ToActionResult<T>(this Result<T> result, IAspNetCoreResultEndpointProfile profile)
        {
            return new ResultToActionResultTransformer().Transform(result, null, profile);
        }

        public static async Task<ActionResult> ToActionResult<T>(this Task<Result<T>> resultTask, IAspNetCoreResultEndpointProfile profile)
        {
            var result = await resultTask;
            return new ResultToActionResultTransformer().Transform(result, null, profile);
        }

        public static ActionResult ToActionResultAndStatusCode<T>(this Result<T> result, HttpStatusCode statusCode)
        {
            return result.ToActionResultAndStatusCode(statusCode, AspNetCoreResult.Settings.DefaultProfile);
        }

        public static ActionResult ToActionResult<T>(this Result<T> result)
        {
            return result.ToActionResult(AspNetCoreResult.Settings.DefaultProfile);
        }

        public static async Task<ActionResult> ToActionResult<T>(this Task<Result<T>> resultTask)
        {
            var result = await resultTask;
            return result.ToActionResult(AspNetCoreResult.Settings.DefaultProfile);
        }

        public static async Task<IActionResult> ActionResult<T>(this Task<Result<T>> resultTask)
        {
            var result = await resultTask;
            return result.ToActionResult(AspNetCoreResult.Settings.DefaultProfile);
        }
    }
}