using Microsoft.EntityFrameworkCore;
using SkillManagement.Contracts;
using SkillManagement.EF.Context;
using SkillManagement.Repositary;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.Practices.Queries;
using SkillMangement.Domain.ProficiencyLevel.Queries;
using SkillMangement.Domain.SkillMatrix.Commands;
using SkillMangement.Domain.SkillMatrix.Queries;
using SkillMangement.Domain.TechnologyStack.Queries;

var policyName = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                           // .WithOrigins("http://localhost:3000")
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});

var connectionString =
    builder.Configuration.GetConnectionString("SkillManagement");

builder.Services.AddDbContext<SkillManagementContext>(options => {
    options.UseSqlServer(connectionString);
});



builder.Services.AddScoped<IPracticesRepository, PracticesRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ITechnologyStackRepository, TechnologyStackRepository>();
builder.Services.AddScoped<IProficiencyLevelRepository, ProficiencyLevelRepository>();
builder.Services.AddScoped<ISkillMatrixRepository, SkillsMatrixRepository>();
builder.Services.AddScoped<IPractices, GetPractices>();

builder.Services.AddScoped<ICategories, GetCategories>();
builder.Services.AddScoped<IProficiencyLevel, GetProficiencyLevel>();
builder.Services.AddScoped<ITechnologyStack, GetTechnologyStack>();
builder.Services.AddScoped<ISkillMatrix, GetSkillMatrix>();
builder.Services.AddScoped<ICreateSkillMatrix, CreateSkillMatrix>();
builder.Services.AddScoped<IUpdateSkillMatrix, UpdateSkillMatrix>();


//builder.Services.AddScoped(GetPractices);
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
