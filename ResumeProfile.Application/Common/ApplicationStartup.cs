namespace ResumeProfile.Application.Common
{
    public static class ApplicationStartup
    {
        public static void ApplicationConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region serilog
            var logConStr = AESService.Decrypt(configuration.GetConnectionString("LogDbConnection"));
            Log.Logger = new LoggerConfiguration()
            .Enrich.With(new ShadowPropertyEnricher(new HttpContextAccessor(), configuration))
            .Enrich.FromLogContext()
            .WriteTo.MSSqlServer(logConStr, "AppLogEvents", autoCreateSqlTable: true)
            .CreateLogger();

            services.AddSingleton(Log.Logger);

            #endregion

            #region DI ( Registeration Services )

            services.AddHttpClient();
            services.AddMemoryCache();
            services.AddScoped<IErrorLogger, ErrorLogger>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ILogRepository<>), typeof(LogRepository<>));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<IApplicationSettingService, ApplicationSettingService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region Idp Registration

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();



            services.AddIdentity<User, Role>().AddEntityFrameworkStores<SqlServerApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<SecurityStampValidatorOptions>(option =>
            {
                option.ValidationInterval = TimeSpan.FromSeconds(5);
            });

            var jwtSettings = configuration.GetSection("JwtSettings");

            //// Add JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = AESService.Decrypt(jwtSettings["Issuer"]),
                     ValidAudience = AESService.Decrypt(jwtSettings["Audience"]),
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(AESService.Decrypt(jwtSettings["Key"])))
                 };

                 options.Events = new JwtBearerEvents
                 {
                     OnChallenge = async context =>
                     {
                         context.HandleResponse();

                         context.Response.StatusCode = StatusCodes.Status403Forbidden;
                         context.Response.ContentType = "application/json";
                         var result = OkApiResult<string>.Fail("the Token is not valid.", 403);
                         await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(result));
                     },
                     OnForbidden = async context =>
                     {
                         context.Response.StatusCode = StatusCodes.Status403Forbidden;
                         context.Response.ContentType = "application/json";

                         var result = OkApiResult<string>.Fail("forbidden", 403);
                         await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(result));
                     }
                 };
             });



            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            });

            #endregion

            #region MadiatR
            // ثبت MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(InputSanitizationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ErrorLoggingBehavior<,>));
            services.AddControllers()
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            // ثبت تمام Validatorها
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // ثبت ValidationBehavior به عنوان Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            #endregion
        }
    }
}