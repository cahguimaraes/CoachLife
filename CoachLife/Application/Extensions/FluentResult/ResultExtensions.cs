﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CoachLife.Application.Extensions.FluentResult
{
    public static class ResultExtensions
    {
        public static ActionResult ToActionResult(this Result result, IAspNetCoreResultEndpointProfile profile)
        {
            return new ResultToActionResultTransformer().Transform(result, profile);
        }
        public static async Task<ActionResult> ToActionResult(this Task<Result> resultTask, IAspNetCoreResultEndpointProfile profile)
        {
            var result = await resultTask;
            return new ResultToActionResultTransformer().Transform(result, profile);
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

        public static ActionResult ToActionResult<T>(this Result<T> result, IAspNetCoreResultEndpointProfile profile)
        {
            return new ResultToActionResultTransformer().Transform(result, profile);
        }

        public static async Task<ActionResult> ToActionResult<T>(this Task<Result<T>> resultTask, IAspNetCoreResultEndpointProfile profile)
        {
            var result = await resultTask;
            return new ResultToActionResultTransformer().Transform(result, profile);
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
    }
}