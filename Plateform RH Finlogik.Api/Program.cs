

using Microsoft.Extensions.FileProviders;
using Plateform_Rh_Finlogik.InfrastructureMail;
using Plateform_RH_Finlogik.Api.Middleware;
using Plateform_RH_Finlogik.Application;
using Plateform_RH_Finlogik.Application.Contracts.EmailCandidat;
using Plateform_RH_Finlogik.Application.Features.HubClient;
using Plateform_RH_Finlogik.Application.Models.EmailCandidat;
using Plateform_RH_Finlogik.Persistance;
using Plateform_RH_Finlogik_._JWT;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddJwtServices(builder.Configuration);
builder.Services.AddInfrastructureServices();


builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true)
           .AllowCredentials();
});
});


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


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


app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<BroadcastHub>("/notify");
});



app.MapRazorPages();

app.UseCustomExceptionHandler();

app.Run();
