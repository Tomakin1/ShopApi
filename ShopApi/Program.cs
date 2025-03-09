using Microsoft.EntityFrameworkCore;
using ShopApi.Context;
using ShopApi.Repositories.Implementations;
using ShopApi.Repositories.Interfaces;
using System.Net;  // HttpStatusCode için gerekli namespace
using System.Text.Json;  // JsonSerializer için gerekli namespace

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
                // JSON serile?tirme ayarlar?n? özelle?tiriyoruz
            })
            .AddJsonOptions(options =>
            {
                // Küçük harfli camelCase kullan?m?
                options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;

                // Null de?erleri serile?tirmemek
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var connStr = builder.Configuration.GetConnectionString("dockerConnection");
            builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(connStr));

            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();

            var app = builder.Build();

            // HTTP istek pipeline'?n? yap?land?r?yoruz
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // HTTPS yönlendirmesini ve kimlik do?rulamay? ekliyoruz
            app.UseHttpsRedirection();
            //app.UseAuthorization();

            // Hata i?leme middleware'ini ekliyoruz
            app.UseMiddleware<ErrorHandlingMiddleware>();

            // Controller'lar? mapliyoruz
            app.MapControllers();

            app.Run();
        }
    }

    //--------------------------------GPT GLOBAL HATA YÖNETİMİ KODLARI----------------------------
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
                await HandleExceptionAsync(httpContext, ex); // Hata i?leme fonksiyonunu ça??r
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Hata detaylar?n? JSON format?nda döndürme
            var errorResponse = new
            {
                message = "Sunucuda bir hata olu?tu. Lütfen daha sonra tekrar deneyin.",
                detail = exception.Message
            };

            var errorJson = JsonSerializer.Serialize(errorResponse);
            return context.Response.WriteAsync(errorJson);
        }
    }
}
