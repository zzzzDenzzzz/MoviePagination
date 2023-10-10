using Movie.Extensions;
using Movie.Options;
using Movie.Services;

var builder = WebApplication.CreateBuilder(args);


//class int = 10;
//class class = 20;
//int void = 20;


//int name;
//int _name;
//int _1234;

//int @static = 20;
//Console.WriteLine(@static);


//string a;

//string name = "Oleq";
//name.farid();



builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddControllersWithViews();

//Console.WriteLine("Key     : " + builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("ApiKey"));
//Console.WriteLine("BaseUrl : " + builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("BaseUrl"));

//Console.WriteLine("Key     : " + builder.Configuration["ConnectionStrings:ApiKey"]);
//Console.WriteLine("BaseUrl : " + builder.Configuration["ConnectionStrings:BaseUrl"]);



//builder.Services.AddSingleton();
//builder.Services.AddScoped();


//builder.Services.Configure<MovieApiOptions>(options =>
//{
//    options.ApiKey = builder.Configuration["ConnectionStrings:ApiKey"];
//    options.BaseUrl = builder.Configuration["ConnectionStrings:BaseUrl"];
//});



//builder.Services.Test();
//string f = " ";
//f.Test(10);

//  update Person
// extensions Update()
// extensions<T> Update<Person>()

builder.Services.AddMovieService(options =>
{
    options.ApiKey = builder.Configuration["ConnectionStrings:ApiKey"];
    options.BaseUrl = builder.Configuration["ConnectionStrings:BaseUrl"];
});

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
