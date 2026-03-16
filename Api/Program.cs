var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceCollection(builder.Configuration);

var app = builder.Build();
app.Services.AddCustomService(builder.Configuration);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();