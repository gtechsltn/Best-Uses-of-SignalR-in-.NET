using RealTimeClientApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();  // Add SignalR service


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// In your Startup.cs or Program.cs (for .NET 6+)
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:5270") // Allow requests from this origin
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials());


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<MessageHub>("/messagehub"); // Ensure the endpoint matches

app.Run();
