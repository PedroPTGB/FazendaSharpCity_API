using FazendaSharpCity_API.Authorization;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Models;
using FazendaSharpCity_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;
var connectionString = builder.Configuration.GetConnectionString("FSCConnection");
builder.Services.AddDbContext<ApiContext>(opts => opts.UseLazyLoadingProxies().UseNpgsql(connectionString));
builder.Services.AddDbContext<UsuarioContext>(opts => opts.UseNpgsql(connectionString));

builder.Services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<UsuarioContext>().AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = false,
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ahjqarpweoit34982431094hdfkajsdh98")),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
        ValidateAudience = false, 
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true
        
    };
});

builder.Services.AddSingleton<IAuthorizationHandler, NivelGerencialAuthorization>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("NivelGerencial", policy => policy.AddRequirements(new NivelGerencial(true))
    );
    options.AddPolicy("IsFuncionario", policy => policy.AddRequirements(new IsFuncionario(true))
    );
    options.AddPolicy("TempoDeAcessoToken", policy => policy.AddRequirements(new TempoDeAcessoToken(true))
    );
});

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Non Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
