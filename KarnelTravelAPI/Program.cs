using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using KarnelTravelAPI.Repository.MultiServiceRepository;
using KarnelTravelAPI.Service;
using KarnelTravelAPI.Service.ImageService;
using KarnelTravelAPI.Service.MultiServiceModel;
using KarnelTravelAPI.Serviece;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration
   .GetConnectionString("ConnectDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<ITouristSpotRepository,TouristSpotServiceImp>();
builder.Services.AddScoped<ITouristSpotImageRepository, TouristSpotImageServiceImp>();
builder.Services.AddScoped<ILocationImageRepository, LocationImageServiceImp>();
builder.Services.AddScoped<ILocationRepository, LocationRepositoryImp>();
builder.Services.AddScoped<IAccommodationRepository, AccommodationRepositoryImp>();
builder.Services.AddScoped<IAccommodationImageRepository, AccommodationImageServiceImp>();
builder.Services.AddScoped<ITransportRepository, TransportServiceImp>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImp>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantServiceImp>();
builder.Services.AddScoped<IRestaurantImageRepository, ResImgServiceImp>();
builder.Services.AddScoped<ITourRepository, TourServiceImp>();
builder.Services.AddScoped<IPaymentRepository, PaymentServiceImp>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackServiceImp>();
builder.Services.AddScoped<IBookingRepository, BookingServiceImp>();
builder.Services.AddScoped<IAccommodationTourRepository, AccommodationTourServiceImp>();
builder.Services.AddScoped<IRestaurantTourRepository, RestaurantTourServiceImp>();
builder.Services.AddScoped<ITouristSpotTourRepository, TouristSpotTourServiceImp>();
builder.Services.AddScoped<ITransportTourRepository, TransportTourServiceImp>();




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});




var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "uploads")),
    RequestPath = "/uploads"
});
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
