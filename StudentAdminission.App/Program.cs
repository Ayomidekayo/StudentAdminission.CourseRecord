using Microsoft.EntityFrameworkCore;
using StudentAdmission.Data;
using StudentAdminission.App.Endpoints;
using StudentAdminission.App.Configuration;
using StudentAdmission.Data.Contracts;
using StudentAdmission.Data.Repositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StudentAdminission.App.Services;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
var con = builder.Configuration.GetConnectionString("DefaultCon");
builder.Services.AddDbContext<StudentAdministionDbContext>(option =>
{
    option.UseSqlServer(con);
});
builder.Services.AddIdentityCore<SchoolUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StudentAdministionDbContext>();
//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
})      
    .AddJwtBearer(option =>
    {
        var tokenvalidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWTSetting:Issuer"],
            ValidAudience = builder.Configuration["JWTSetting:Audience"],
            ValidateLifetime=true,
            ClockSkew=TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSetting:Key"]))
        };
    });
//authorization
builder.Services.AddAuthorization(option =>{
    option.FallbackPolicy= new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//htttpContext
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IAuthManager, Authmanager>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfigProfile));
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapStudentEndpoints();
app.MapAuthenticationEndpoint();
app.MapCourseEndpoints();

app.MapEnrollmentEndpoints();


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}