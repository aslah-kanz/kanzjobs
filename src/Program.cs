using Hangfire;
using Hangfire.SqlServer;
using KanzwayCron.Data.Context;
using KanzwayCron.Jobs;
using KanzwayCron.Repositories;
using KanzwayCron.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KanzDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KanzwayConnection")));

builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));

builder.Services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();
builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();
builder.Services.AddSingleton<IHttpRequestRepository, HttpRequestRepository>();

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

var username = builder.Configuration["BasicAuthentication:Username"];
var password = builder.Configuration["BasicAuthentication:Password"];

app.UseHangfireDashboard("/dashboard", new DashboardOptions
{
    Authorization = new[] { new BasicAuthAuthorizationFilter(username!, password!) }
});

app.Run();
