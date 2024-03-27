using AutoMapper;
using EmployeeManagementEF.Data;
using EmployeeManagementEF.Helpers;
using EmployeeManagementEF.Mapper;
using EmployeeManagementEF.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Adding DB
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultValue")));

var config = new MapperConfiguration(cfg => {
    cfg.AddProfile(new MappingProfile());
});

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

// Configure CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

// Register Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope()) {
    var Departments = scope.ServiceProvider.GetService(typeof(IDepartmentService)) as IDepartmentService;
    var Employee = scope.ServiceProvider.GetService(typeof(IEmployeeService)) as IEmployeeService;

    await SeedHelper.SeedData(departmentService: Departments, employeeService: Employee);
}

app.Run();
