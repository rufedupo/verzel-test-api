using verzel_test_api.config;

var builder = WebApplication.CreateBuilder(args);

StartAPI(builder);

void StartAPI(WebApplicationBuilder builder)
{
    ConfigureServices(builder);
    var app = builder.Build();
    app.MapControllers();
    app.UseSwagger();
    app.UseSwaggerConfiguration();
    app.UseCorsConfiguration();
    app.Run();
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDefaultConfiguration();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddCorsConfiguration();
    builder.Services.AddSwaggerConfiguration();
}
