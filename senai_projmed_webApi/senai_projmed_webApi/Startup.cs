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

namespace senai_projmed_webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // adicionando um serivco para permitir a leitura dos controllers
            // define o uso de controllers
            services.AddControllers();

            // Adicionar o servico do swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "senai_projmed_webApi", Version = "v1" });

                //Set the comments path for the Swagger JSON and UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            
            });

            // servico 
            services
                // define a forma de autenticação do JwtBearer
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                //definimos os parâmetros de validação do token
                .AddJwtBearer("JwtBearer", options => {

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // quem está omitindo (quem gerou o token)
                        ValidateIssuer = true,

                        // quem está recebendo (quem esta recebendo token para validar)
                        ValidateAudience = true,

                        //vamos validar o tempo de expiração (tempo de vida do token)
                        ValidateLifetime = true,

                        //forma de criptografia e a chave de autenticação               (a validação da chave é validada aqui)
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("key-authentication")),

                        //tempo de expiração do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // nome do issuer de onde está vindo
                        ValidIssuer = "senai_projMedical",

                        // nome audience para onde está indo 
                        ValidAudience = "senai_projmed_webApi",

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

            //definir o uso do swagger
            app.UseSwagger();

            //especificando o swagger JSON endpoint  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "senai_projmed_webApi");
            });

            //habilitamos a autenticação(serve para verificar se o usuario está logado, se permiti ou nao)
            app.UseAuthentication();

            // cuida das condições
            app.UseAuthorization();



            // Habilita a autenticação
            app.UseAuthentication();

            // Habilita a autorização
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // define o mapeamento dos controllers
                endpoints.MapControllers();
            });
        }
    }
}
