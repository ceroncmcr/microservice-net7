using AFORO255.MS.TEST.Pay.Data;
using AFORO255.MS.TEST.Pay.Persistences;
using AFORO255.MS.TEST.Pay.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(opt => 
{
    opt.UseMySQL(builder.Configuration["mysql:cn"]);
});
builder.Services.AddScoped<IPaymentServices, PaymentService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

DbCreated.CreateDbIfNotExists(app);

app.Run();
