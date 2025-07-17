using BeatHealth.Services;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<MySqlConnection>(
    _=>new MySqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();


var app = builder.Build();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();

