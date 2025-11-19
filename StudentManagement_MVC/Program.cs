using Microsoft.EntityFrameworkCore;
using StudentManagement_MVC.Data;
using StudentManagement_MVC.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<StudenManagementContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefCon"))); 
/*
 * cau lenh ben tren giup minh co the them context vao trong controller, service.
 * nhan connectionstring trong appsettings.json.
 * enable EF core do viet tich hop va truy van 
 */


builder.Services.AddScoped<ITF_Score,ScoreService>();
builder.Services.AddScoped<ITF_Student,StudentService>();
builder.Services.AddScoped<ITF_Subject,SubjectService>();
builder.Services.AddScoped<ITF_Teacherlog,TeacherlogService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Teacherlog}/{action=FindTeacherByUname}/{id?}")
    .WithStaticAssets();


app.Run();
