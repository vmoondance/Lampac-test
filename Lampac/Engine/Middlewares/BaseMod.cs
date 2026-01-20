using Microsoft.AspNetCore.Http;
using Shared;
using System.Threading.Tasks;

namespace Lampac.Engine.Middlewares
{
    public class BaseMod
    {
        private readonly RequestDelegate _next;

        public BaseMod(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var disble = AppInit.conf.BaseModule.DisableControllers;

            if (disble.admin && context.Request.Path.Value.StartsWith("/admin"))
                return Task.CompletedTask;

            if (disble.bookmark && context.Request.Path.Value.StartsWith("/bookmark"))
                return Task.CompletedTask;

            if (disble.storage && context.Request.Path.Value.StartsWith("/storage"))
                return Task.CompletedTask;

            if (disble.timecode && context.Request.Path.Value.StartsWith("/timecode"))
                return Task.CompletedTask;

            if (disble.corseu && context.Request.Path.Value.StartsWith("/corseu"))
                return Task.CompletedTask;

            if (disble.media && context.Request.Path.Value.StartsWith("/media"))
                return Task.CompletedTask;

            return _next(context);
        }
    }
}
