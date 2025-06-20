namespace BankingSystem.API.Extensions;

public static class ApplicationBuilderExtensions
{
	public static IServiceCollection ConfigureControllers(this IServiceCollection services)
	{
		services.AddControllers(configure =>
		{
			configure.Filters.AddApplicationFilters();
		})
		.AddJsonOptions(options =>
		{
			options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		});

		return services;
	}

	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		#region Repositories

		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<ITransactionRepository, TransactionRepository>();
		services.AddScoped<IAuthRepository, AuthRepository>();

		#endregion

		#region Services

		services.AddScoped<ITransactionService, TransactionService>();
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<IJwtProvider, JwtProvider>();

		#endregion

		return services;
	}

	public static IServiceCollection ConfigureDataBase(this IServiceCollection services, WebApplicationBuilder builder)
	{
		var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
		services.AddDbContext<BankingSystemDbContext>(options =>
			options.UseSqlServer(connectionString));

		return services;
	}

	public static IServiceCollection AddApplicationAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
	{
		var jwtSettings = builder.Configuration;

		services
			.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(opt =>
			{
				opt.RequireHttpsMetadata = false;
				opt.SaveToken = true;
				opt.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Jwt:Secret"]!)),
					RoleClaimType = ClaimTypes.Role,
				};
			});
		services.ConfigureOptions<JwtOptionsSetup>();
		services.AddAuthorization();

		return services;
	}

	public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
	{
		return services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking System API", Version = "v1" });
			c.UseInlineDefinitionsForEnums();

			c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey,
				Scheme = "Bearer",
				BearerFormat = "JWT",
				Description = "Enter your Bearer token in the format 'Bearer {token}'"
			});

			c.AddSecurityRequirement(new OpenApiSecurityRequirement()
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					new string[] { }
				}
			});

		});
	}

}

public static class ExceptionStatusCodeMappings
{
	public static Dictionary<Type, int> ExceptionStatusCode { get; } = new();

	public static void AddExceptionStatusCodeMappings(this IServiceCollection services)
	{
		var targetAssembly = AppDomain.CurrentDomain
			.GetAssemblies()
			.FirstOrDefault(a => a.GetName().Name == "BankingSystem.Application");

		var exceptionTypes = targetAssembly.GetTypes()
			.Where(t =>
				t is { IsClass: true, IsAbstract: false } &&
				typeof(Exception).IsAssignableFrom(t) &&
				t.Namespace == "BankingSystem.Application.Exceptions" &&
				t.GetCustomAttribute<ExceptionHttpStatusCodeAttribute>() is not null
			);

		foreach (var exceptionType in exceptionTypes)
		{
			var attribute = exceptionType.GetCustomAttribute<ExceptionHttpStatusCodeAttribute>()!;
			ExceptionStatusCode[exceptionType] = (int)attribute.HttpStatusCode;
		}
	}
}
