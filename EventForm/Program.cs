using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

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


        string connectionString = "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            // Execute database operations
        }
        static void AddEvent(string eventName, DateTime eventDate, string connectionString)
        {
            string query = "INSERT INTO Events (EventName, EventDate) VALUES (@EventName, @EventDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventName", eventName);
                command.Parameters.AddWithValue("@EventDate", eventDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        } 
    }
}