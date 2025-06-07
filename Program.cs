using BadmintonHub.Databases;
using BadmintonHub.Facades;
using BadmintonHub.Mappings;
using BadmintonHub.Services;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
    // Add DbContext and connection string
    builder.Services.AddDbContext<BadmintonHubDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

    // Mapping JWT
    builder.Services.Configure<JwtMapping>(builder.Configuration.GetSection("Jwt"));

    // Mapping Momo
    builder.Services.Configure<MomoMapping>(builder.Configuration.GetSection("MomoPayment"));

    // Mapping Service
    builder.Services.AddScoped<ICourtService, CourtService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IBookingService, BookingService>();
    builder.Services.AddScoped<IBookingCourtFacade, BookingCourtFacade>();
    builder.Services.AddScoped<ICustomerService, CustomerService>();
    builder.Services.AddScoped<IStaffService, StaffService>();
    builder.Services.AddScoped<IMomoService, MomoService>();
    builder.Services.AddScoped<IInfoService, InfoService>();
    builder.Services.AddScoped<IFieldService, FieldService>();
    builder.Services.AddHealthChecks();


    builder.Services.AddHttpContextAccessor();
    builder.Services.AddHttpClient<MomoService>();

    // Add authentication
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(bearer =>
    {
        bearer.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "secret_key"))
        };
    }).AddGoogle(google =>
    {
        google.ClientId = builder.Configuration["GoogleAuth:ClientID"];
        google.ClientSecret = builder.Configuration["GoogleAuth:ClientSecret"];
    });

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
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}