using Proyect;
using Proyect.Core.Repositories;
using Proyect.Core.Services;
using Proyect.Core.Models;
using Proyect.Data.Repoistories;
using Proyect.Service;
using Proyect.Data;
using Proyect.Core;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//1HOME

var builder = WebApplication.CreateBuilder(args);

// הוספת ה-Service
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin()   // מאפשר לכל דף גוגל פתוח לדבר איתו
              .AllowAnyMethod()   // מאפשר POST, GET, וכו'
              .AllowAnyHeader();  // מאפשר לשלוח נתונים (כמו JSON)
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});



// שימוש ב-Service (חובה שזה יהיה אחרי app.UseRouting)

// שימוש בשירות (אחרי builder.Build();)

builder.Services.AddScoped<IUserService, UserServise>();
builder.Services.AddScoped<IClientService, ClientServise>();
builder.Services.AddScoped<ITaskService, TaskServise>();
builder.Services.AddScoped<IClientRepositories, ClientRepository>();
builder.Services.AddScoped<ITaskReositories, TaskRepository>();
builder.Services.AddScoped<IUserRepositories, UserRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<DataContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors();
app.UseShabbatMiddleware();
app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();

app.Run();
