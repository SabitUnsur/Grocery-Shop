using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc(config=>
{
	var policy = new AuthorizationPolicyBuilder().
		RequireAuthenticatedUser().Build();

	config.Filters.Add(new AuthorizeFilter(policy));
	//Authorize all controllers
});	

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
	AddCookie(x=>
	{
		x.LoginPath = "/Login/Index";
	});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Category}/{action=Index}/");


app.MapRazorPages();

app.Run();
