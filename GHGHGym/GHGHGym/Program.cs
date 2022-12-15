using CloudinaryDotNet;
using GHGHGym.Core.Services.EmailSender.Contracts;
using GHGHGym.Core.Services.EmailSender.Models;
using GHGHGym.Infrastructure.Data;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.ModelBinders;
using GHGHGym.UserServices;
using GHGHGym.UserServices.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
}).AddRazorRuntimeCompilation()
.AddMvcOptions(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
});

Account account = new Account()
{
    Cloud = builder.Configuration["Cloudinary:CloudName"],
    ApiKey = builder.Configuration["Cloudinary:ApiKey"],
    ApiSecret = builder.Configuration["Cloudinary:ApiSecret"]
};

Cloudinary cloudinary = new Cloudinary(account);

builder.Services.AddSingleton(cloudinary);
builder.Services.AddTransient<IEmailSender>(x => new SendGridEmailSender(builder.Configuration["SendGrid:ApiKey"]));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddApplicationServices();

builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath = "/User/Login";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{   
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapRazorPages();
});

app.Run();
