using BadmintonHub.Databases;
using BadmintonHub.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    // Add DbContext and connection string
    builder.Services.AddDbContext<BadmintonHubDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

    // Add services to the container.
    builder.Services.AddScoped<ICourtService, CourtService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddHealthChecks();

    builder.Services.AddControllers(options =>
    {
        options.SuppressAsyncSuffixInActionNames = false;
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapHealthChecks("health");
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}