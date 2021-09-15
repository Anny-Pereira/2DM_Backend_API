using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c=>
                {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Filmes.webApi"
                });

                 // Set the comments path for the Swagger JSON and UI.
                 var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                 var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                 c.IncludeXmlComments(xmlPath);
                });

            services
            //Define a forma de autentica��o
            .AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })

                //Define os par�metros de valida��o do token
            .AddJwtBearer("JwtBearer", options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ser� validado o emissor do token
                        ValidateIssuer = true,


                        //ser� validado o destinat�rio do token
                        ValidateAudience = true,

                        //ser� validado o tempo de vida do token
                        ValidateLifetime = true,


                        //Valida a chave de seguran�a
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),

                        ClockSkew = TimeSpan.FromMinutes(30),

                        //Define o nome do issuer, ou seja, quem gerou o token
                        ValidIssuer = "Filmes.WebApi",

                        //Define o nome do audience, ou seja, pra quem se destina a valida��o do token
                        ValidAudience = "Filmes.WebApi"


                    };
                });
        }
       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Filmes.WebApi");
                c.RoutePrefix = string.Empty;
            });


            //Habilita a autentica��o
            app.UseAuthentication();            //401 - autentica��o

            //Habilita a autoriza��o
            app.UseAuthorization();             //403 - autoriza��o

            app.UseEndpoints(endpoints =>
            {
                //Define o mapeamento das controllers
                endpoints.MapControllers();
            });
        }
    }
}
