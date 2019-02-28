using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace hello
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                StringBuilder sb = new StringBuilder("<HTML><BODY> Hello Lars! - local IP: ", 2000);
                sb.Append(context.Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString());
                foreach (string key in context.Request.Query.Keys)
                {
                    sb.Append(string.Format("<p>key: {0}, value: {1}\r\n", key, context.Request.Query[key]));
                }
                sb.Append("</BODY></HTML>");
                // You must close the output stream.
                await context.Response.WriteAsync(sb.ToString());
            });
        }
    }
}
