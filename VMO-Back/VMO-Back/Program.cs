using VMO_Back;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;
using VMO_Back.Repository.Implement;
using Share;

var builder = WebApplication.CreateBuilder(args);


// Connection Db
builder.Services.AddDbContext<Datacontext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectedDb"]);
});

// Config CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Life cycle DI: AddSingleton(), AddTransient(), AddScoped()
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ITitleRepository, TitleRepository>();
builder.Services.AddScoped<IContractTypeRepository, ContractTypeRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IBenefitRepository, BenefitRepository>();
builder.Services.AddScoped<ISalaryProfileRepository, SalaryProfileRepository>();
builder.Services.AddScoped<ISalaryProfileAllowanceRepository, SalaryProfileAllowanceRepositosy>();
builder.Services.AddScoped<ISalaryProfileBenefitRepository, SalaryProfileBenefitRepositosy>();
builder.Services.AddScoped<IAllowanceRepository, AllowanceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
