using WindowsService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddWindowsService();
builder.Services.AddHostedService<Service>();

var app = builder.Build();

app.MapRazorPages();

app.Run();