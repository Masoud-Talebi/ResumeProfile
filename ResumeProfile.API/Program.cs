
using Microsoft.OpenApi.Models;
using ResumeProfile.API.Middlewares;
using ResumeProfile.Application.Common;
using ResumeProfile.Infrastructure.Common;
using Serilog;
using System.Reflection;

namespace DoctorAppointment.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureService(builder.Configuration);
            builder.Services.ApplicationConfigureServices(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("OpenCorsPolicy", policy =>
                {
                    policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                   .AllowAnyHeader();
                });
            });

            // ===== اضافه کردن Swagger =====
            builder.Services.AddEndpointsApiExplorer(); // لازم برای API Explorer
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Doctor Appointment API",
                    Version = "v1",
                    Description = "API documentation for Doctor Appointment project"
                });

                // تعریف Bearer
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token.\r\n\r\nExample: \"Bearer eyJhbGciOi...\"",
                });

                // اجباری کردن برای همه
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            // ===== فعال کردن Swagger =====
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Doctor Appointment API V1");
                c.RoutePrefix = "swagger"; // مسیر دسترسی: /swagger
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("OpenCorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            try
            {
                Log.Information("Application Startup");
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application Startup field");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
