using ZengoApi.Start;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var allowedOrigins = builder.Configuration.GetValue<string>("allowedOrigins")!.Split(",");
builder.Services.ConfigureCors(allowedOrigins);

builder.ConfigureMSSQL();
builder.Services.ConfigureExceptionHandler();
builder.Services.ConfigureMediatR();
builder.Services.ConfigureTransients();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
