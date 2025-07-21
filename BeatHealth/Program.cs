using BeatHealth.Services;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<MySqlConnection>(
    _=>new MySqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var app = builder.Build();

//app.UseExceptionHandler(errorApp =>
//{
//    errorApp.Run(async context =>
//    {
//        context.Response.StatusCode = 500;
//        await context.Response.WriteAsJsonAsync(new
//        {
//            Title = "Unexpected errorrrr",
//            Status = 500,
//            Detail = "Please contact support."
//        });
//    });
//});

app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();

