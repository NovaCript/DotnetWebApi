var builder = WebApplication.CreateBuilder(args);
var stringConnection = builder.Configuration.GetConnectionString("SqliteStringConnection");


builder.Services.AddControllers();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "API списка контактов",
    });
});

builder.Services.AddCors(opt =>
opt.AddPolicy("CorsPolicy", policy =>
{
    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins(builder.Configuration["client"]);
}));


builder.Services.AddSingleton<IStorage>(new SqliteStorage(stringConnection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseCors("CorsPolicy");
app.Run();