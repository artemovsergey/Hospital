using Hospital.Data;
using Hospital.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<HospitalContext>();
builder.Services.AddScoped<PatientRepository>();
builder.Services.AddScoped<MedicalCardRepository>();
builder.Services.AddScoped<DepartamentRepository>();
builder.Services.AddScoped<HospitalizationRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("NewPolicy");


app.Run();
