using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Google.Cloud.Firestore;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace omegaone_test_app
{
    public class Startup
    {
        private const string GoogleApplicationCredentialsEnv = "GOOGLE_APPLICATION_CREDENTIALS";
        private const string GACred = "GACred";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureFirestoreDatabase(services);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureFirestoreDatabase(IServiceCollection services)
        {
            CreateGoogleApplicationCredentialsConfiguration();
            services.AddTransient<FirestoreDb>((ctx) => 
            { 
                return FirestoreDb.Create(GetGoogleApplicationIdFromCredentials()); 
            });
        }

        private void CreateGoogleApplicationCredentialsConfiguration()
        {
            var config = Environment.GetEnvironmentVariable(GACred);
            var configFilePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".json"; 

            StreamWriter streamWriter = File.CreateText(configFilePath);
            streamWriter.WriteLine(config);
            streamWriter.Flush();
            streamWriter.Close();
            Environment.SetEnvironmentVariable(GoogleApplicationCredentialsEnv, configFilePath);
        }

        private string GetGoogleApplicationIdFromCredentials()
        {
            const string projectIdKey = "project_id";

            var o1 = JObject.Parse(File.ReadAllText(Environment.GetEnvironmentVariable(GoogleApplicationCredentialsEnv)));
            return o1.GetValue(projectIdKey).ToString();
        }
    }
}
