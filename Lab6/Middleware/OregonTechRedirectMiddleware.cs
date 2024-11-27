namespace Lab6.Middleware
{
    public class OregonTechRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public OregonTechRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(state => {
                var context = (HttpContext)state;
                context.Response.StatusCode = 302;
                
                return Task.CompletedTask;
            }, context);

            context.Response.Headers.Add("location", "https://www.oit.edu");
        }
    }
}

