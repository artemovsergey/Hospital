using Hospital.Data;
using Hospital.ManagmentFlowPatients.Components;
using Hospital.Service.Interfaces;
using Hospital.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<HospitalContext>();

builder.Services.AddScoped<PatientRepository>();
builder.Services.AddScoped<MedicalCardRepository>();
builder.Services.AddScoped<HospitalizationRepository>();
builder.Services.AddScoped<DepartamentRepository>();

builder.Services.AddTransient<Blazor.QrCodeGen.ModuleCreator>();

builder.Services.AddServerSideBlazor().AddHubOptions(o =>
{
    o.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10mb max file size
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
