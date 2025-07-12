using BeatHealth.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DoctorService>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();

