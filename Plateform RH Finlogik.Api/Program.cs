

using Microsoft.Extensions.FileProviders;
using Plateform_RH_Finlogik.Api.Middleware;
using Plateform_RH_Finlogik.Application;
using Plateform_RH_Finlogik.Persistance;
using Plateform_RH_Finlogik_._JWT;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddJwtServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Ressources")),
    RequestPath = new PathString("/Ressources")
});
app.UseCors("EnableCORS");

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCustomExceptionHandler();

app.UseCors("Open");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



app.MapRazorPages();

app.UseCustomExceptionHandler();

app.Run();
