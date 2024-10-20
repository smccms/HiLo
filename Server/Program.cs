
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<HLHub>();
builder.Services.AddTransient<IHiLoGame, HiLoGame>(); 

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<HLHub>("/hl");
});

app.Run();

