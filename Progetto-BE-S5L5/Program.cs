using FluentEmail.MailKitSmtp;
using Microsoft.EntityFrameworkCore;
using Progetto_BE_S5L5.Data;
using Progetto_BE_S5L5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddFluentEmail(builder.Configuration.GetSection("MailSettings").GetValue<string>("FromDefault")).AddRazorRenderer().AddMailKitSender(new SmtpClientOptions()
{
    Server = builder.Configuration.GetSection("MailSettings").GetValue<string>("Server"),
    Port = builder.Configuration.GetSection("MailSettings").GetValue<int>("Port"),
    User = builder.Configuration.GetSection("MailSettings").GetValue<string>("Username"),
    Password = builder.Configuration.GetSection("MailSettings").GetValue<string>("Password"),
    UseSsl = builder.Configuration.GetSection("MailSettings").GetValue<bool>("UseSSL"),
    RequiresAuthentication = builder.Configuration.GetSection("MailSettings").GetValue<bool>("RequiresAuthentication"),
});

builder.Services.AddScoped<AnagraficaServices>();
builder.Services.AddScoped<VerbaleServices>();
builder.Services.AddScoped<ViolazioneServices>();
builder.Services.AddScoped<FiltroServices>();
builder.Services.AddScoped<EmailServices>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
