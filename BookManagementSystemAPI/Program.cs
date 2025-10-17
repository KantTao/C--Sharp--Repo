using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using BookManagementSystemAPI.Data;
using Microsoft.EntityFrameworkCore;
using BookManagementSystemAPI.Exceptions;
using BookManagementSystemAPI.Models;
using BookManagementSystemAPI.Repository;
using BookManagementSystemAPI.Services;
using BookManagementSystemAPI.Settings;
using BookManagementSystemAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace BookManagementSystemAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //
            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
            );

            
            // builder.Services.AddControllers()
            //     .AddFluentValidation(fv => 
            //         fv.RegisterValidatorsFromAssemblyContaining<BookCreateValidator>()
            //     )
            //     .AddJsonOptions(options =>
            //         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
            //     );


            //新 API：自动启用 FluentValidation
            builder.Services.AddFluentValidationAutoValidation();
            //扫描当前程序集里的所有验证器
            builder.Services.AddValidatorsFromAssemblyContaining<BookCreateValidator>();

            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookDb"))
            );
            
            
            
            //Identity 框架里USER表结构 和默认规则 Role
            builder.Services.AddIdentity<User, IdentityRole>() //使用自定义的User
                .AddEntityFrameworkStores<BookDbContext>()
                .AddDefaultTokenProviders();
            
            
            
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                }
            );

            
            //Identity 的自定义User模型
            //builder.Services.AddIdentity<User , IdentityRole>();
            
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IAuthService,AuthService>();
            
            // --- AutoMapper 注入 ---
            //依赖注入AddAutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddSingleton<GlobalExceptionHandler>();

            //把"AppInfo" 这个值 from appsettings.json 绑定到了AppInfo class里去
            builder.Services.Configure<AppInfo>(builder.Configuration.GetSection("AppInfo"));
            
            //Validator的注入 
            builder.Services.AddScoped<IValidator<BookCreateRequest>, BookCreateValidator>();
            
            //添加swagger服务
            builder.Services.AddSwaggerGen(c =>
            {
                var xmFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            
            builder.Logging.AddDebug();
            builder.Logging.AddConsole();

            var app = builder.Build();

            //使用 Swagger 中间件

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler(errorApp => errorApp.Run(async context =>
                {
                    var exceptionHandler = context.RequestServices.GetRequiredService<GlobalExceptionHandler>();
                    await exceptionHandler.HandleExceptionAsync(context);
                }
            ));
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();
            app.Run();
        }
    }
}