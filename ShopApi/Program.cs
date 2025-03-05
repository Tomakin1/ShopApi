using Microsoft.EntityFrameworkCore;
using ShopApi.Context;
using ShopApi.Repositories.Implementations;
using ShopApi.Repositories.Interfaces;
using System.Net;  // HttpStatusCode i�in gerekli namespace
using System.Text.Json;  // JsonSerializer i�in gerekli namespace

namespace ShopApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers(options =>
            {
                // JSON serile?tirme ayarlar?n? �zelle?tiriyoruz
            })
            .AddJsonOptions(options =>
            {
                // K���k harfli camelCase kullan?m?
                options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;

                // Null de?erleri serile?tirmemek
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            // Swagger/OpenAPI yap?land?rmas?n? ekliyoruz
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Veritaban? ba?lant?s?n? ayarl?yoruz
            var connStr = builder.Configuration.GetConnectionString("dockerConnection");
            builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(connStr));

            // Repository ve servisleri ekliyoruz
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // HTTP istek pipeline'?n? yap?land?r?yoruz
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // HTTPS y�nlendirmesini ve kimlik do?rulamay? ekliyoruz
            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Hata i?leme middleware'ini ekliyoruz
            app.UseMiddleware<ErrorHandlingMiddleware>();

            // Controller'lar? mapliyoruz
            app.MapControllers();

            app.Run();
        }
    }

    // ErrorHandlingMiddleware s?n?f?
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); // ?stek pipeline'?n? devam ettir
            }
            catch (Exception ex)
            {
                _logger.LogError($"Bir hata olu?tu: {ex.Message}");
                await HandleExceptionAsync(httpContext, ex); // Hata i?leme fonksiyonunu �a??r
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Hata detaylar?n? JSON format?nda d�nd�rme
            var errorResponse = new
            {
                message = "Sunucuda bir hata olu?tu. L�tfen daha sonra tekrar deneyin.",
                detail = exception.Message
            };

            var errorJson = JsonSerializer.Serialize(errorResponse);
            return context.Response.WriteAsync(errorJson);
        }
    }
}
