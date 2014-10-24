using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OwinWebApi.Infrastructure.Middleware
{
    public class LoggingMiddleware : OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            Console.WriteLine("Begin Request");
            await Next.Invoke(context);
            Console.WriteLine("End Request");
        }
    }
}