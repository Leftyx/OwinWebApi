using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinWebApi.api
{
    [RoutePrefix("api/1.0.0")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("test")]
        public async Task<IHttpActionResult> Get()
        {
            string name = "Mister";
            string sayHello = string.Empty;

            Task<string> t = new Task<string>(() =>
            {
                sayHello = string.Format("Hello {0}", name);
                return sayHello;
            });
            t.Start();
            await t;

            return Ok(new string[] { sayHello });
        }
    }
}
