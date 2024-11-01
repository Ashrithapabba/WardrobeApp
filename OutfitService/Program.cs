using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OutfitService.Data;
using OutfitService.Mapping;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OutfitContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly); 
builder.Services.AddControllers();

var retryPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(3)); // Exponential backoff

var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10); // 10-second timeout

var circuitBreakerPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .CircuitBreakerAsync(5, TimeSpan.FromSeconds(3));

var closetServiceBaseUrl = builder.Configuration["ClosetService__BaseUrl"];
builder.Services.AddHttpClient("ClosetService", client =>
{
    client.BaseAddress = new Uri(closetServiceBaseUrl);
})
.AddPolicyHandler(retryPolicy)
.AddPolicyHandler(timeoutPolicy)
.AddPolicyHandler(circuitBreakerPolicy);

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<OutfitContext>();
    DbInitializer.InitDb(app); 
}

app.Run();


// static IAsyncPolicy<HttpResponseMessage> GetPolicy()
//     => HttpPolicyExtensions
//         .HandleTransientHttpError()
//         .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
//         .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(3));
