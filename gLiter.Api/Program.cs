using System;
using gLiter.Api.Config;
using gLiter.Api.Middlewares;
using gLiter.Api.StartupExtensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "gLiter Gas Station API",
        Version = "v1",
        Description = "gLiter backend API with JWT auth and localization"
    });

    options.EnableAnnotations();
    options.OperationFilter<FormFileOperationFilter>();

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter 'Bearer {token}'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityDefinition("Bearer", securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddBusinessServices();
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddLocalizationSetup();
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",
            "http://localhost:3000",
            "https://yourdomain.com",      // TODO: Replace with your actual domain
            "https://www.yourdomain.com"   // TODO: Replace with your actual domain
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseRequestLocalization(LocalizationConfig.GetOptions());

// 1. CORS Policy
app.UseCors("AllowReact");

// 2. Swagger (Keep enabled for debugging if needed, or wrap in IsDevelopment)
app.UseSwagger();
app.UseSwaggerUI();

// 3. Security & Redirection
app.UseHttpsRedirection();

// 4. Static Files (Critical for React)
// First, serve default files (index.html) if the root is requested
app.UseDefaultFiles(); 
// Then serve the actual static files from wwwroot
app.UseStaticFiles();

// 5. Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 6. Map API Controllers
app.MapControllers();

// 7. Fallback for SPA (React Router)
// Requests that don't match files or API endpoints will be served index.html
app.MapFallbackToFile("index.html");

app.Run();
