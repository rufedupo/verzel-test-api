using verzel_test_api.config;
using verzel_test_api.infra.Contexts;

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
    app.UseAuthentication();
    app.UseAuthorization();
    app.Run();
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<DatabaseContext>();
    builder.Services.InjectionDependency();
    builder.Services.AddDefaultConfiguration();
    builder.Services.AddControllers();
    builder.Services.AuthenticationConfig();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddCorsConfiguration();
    builder.Services.AddSwaggerConfiguration();
}
