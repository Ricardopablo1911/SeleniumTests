using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.FileProviders;


using System.IO;
/*
var localizacao = SalvarCaminho.Usar.pasta;
var local = Path.GetDirectoryName(localizacao);
var caminho = Path.Combine(local, "caminho");

var endereco = SalvarCaminho.Usar.email;
var Eletronico = Path.GetDirectoryName(endereco);
var email = Path.Combine(Eletronico, "email");

var sistema = SalvarCaminho.Usar.linkSistema;
var sistemLink = Path.GetDirectoryName(sistema);
var linkSistema = Path.Combine(sistemLink, "link");
*/



namespace InterfaceTestes
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            // Configura o middleware do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Especifica a rota da API do Swagger
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");

                // Configura o middleware para servir arquivos estáticos
                c.RoutePrefix = string.Empty; // define a raiz como o prefixo
                c.DocumentTitle = "Swagger UI"; // define o título da página
                c.IndexStream = () => // define a ação que retorna o stream do index.html
                {
                    var assembly = typeof(Startup).Assembly;
                    var resourceStream = assembly.GetManifestResourceStream("API.wwwroot.index.html"); // substitua "NomeDaSuaAPI" pelo nome da sua API
                    return new StreamReader(resourceStream).BaseStream;
                };


                app.UseStaticFiles();
                // Adiciona o middleware de arquivo estático para servir a pasta que contém o index.html
                /*app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                    RequestPath = ""
                });*/
            });



            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InterfaceServer v1"));

                app.UseCors(policy => policy.AllowAnyOrigin()); 

	    
	        }*/

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

