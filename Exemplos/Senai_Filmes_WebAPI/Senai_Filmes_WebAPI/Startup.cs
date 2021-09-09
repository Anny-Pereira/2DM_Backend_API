using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
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

            services
            //Define a forma de autenticação
            .AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })

                //Define os parâmetros de validação do token
            .AddJwtBearer("JwtBearer", options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //será validado o emissor do token
                        ValidateIssuer = true,


                        //será validado o destinatário do token
                        ValidateAudience = true,

                        //será validado o tempo de vida do token
                        ValidateLifetime = true,


                        //Valida a chave de segurança
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),

                        ClockSkew = TimeSpan.FromMinutes(30),

                        //Define o nome do issuer, ou seja, quem gerou o token
                        ValidIssuer = "Filmes.WebApi",

                        //Define o nome do audience, ou seja, pra quem se destina a validação do token
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


            //Habilita a autenticação
            app.UseAuthentication();            //401 - autenticação

            //Habilita a autorização
            app.UseAuthorization();             //403 - autorização

            app.UseEndpoints(endpoints =>
            {
                //Define o mapeamento das controllers
                endpoints.MapControllers();
            });
        }
    }
}
