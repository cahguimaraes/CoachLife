namespace CoachLife.Application.Extensions.FluentResult
{
    public class AspNetCoreResultSettings
    {
        public IAspNetCoreResultEndpointProfile DefaultProfile { get; set; } = new DefaultAspNetCoreResultEndpointProfile();
    }
}