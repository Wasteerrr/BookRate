using api.Data;
using api.Interfaces;
using api.Models;
using api.Repository;
using api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(options => {options.SerializerSettings.ReferenceLoopHandling =  Newtonsoft.Json.ReferenceLoopHandling.Ignore;});

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    })
.AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = 
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme = 
    options.DefaultScheme = 
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IReadRepository, ReadRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IBMPService, BMPService>();
builder.Services.AddHttpClient<IBMPService, BMPService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookRate API v1");
});

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithOrigins("http://localhost:3000")
    .SetIsOriginAllowed(origin => true)
    );

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Migration failed: " + ex.Message);
    }
}

app.Run();


