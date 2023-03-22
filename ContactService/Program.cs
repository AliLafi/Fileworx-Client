using WorkerService1;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddWindowsService();
builder.Services.AddHostedService<Worker>();
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();