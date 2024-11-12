using DartApp.Data;
using DartApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DartApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Voeg de DbContext toe
            builder.Services.AddDbContext<DartAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // **Voeg standaardgegevens toe bij het opstarten**
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DartAppContext>();
                AddDefaultData(context);
            }

            app.Run();
        }

        // Methode om standaardgegevens toe te voegen
        private static void AddDefaultData(DartAppContext context)
        {
            try
            {
                // Voeg GameModes toe als ze niet bestaan
                if (!context.GameModes.Any())
                {
                    Console.WriteLine("GameModes worden toegevoegd.");

                    // Schakel tijdelijk IDENTITY_INSERT in
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT GameModes ON");

                    context.GameModes.AddRange(
                        new GameMode301 { GameModeId = 1, Name = "301" },
                        new GameMode501 { GameModeId = 2, Name = "501" },
                        new Tactics { GameModeId = 3, Name = "Tactics" }
                    );
                    context.SaveChanges();

                    // Schakel IDENTITY_INSERT weer uit
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT GameModes OFF");
                    Console.WriteLine("GameModes succesvol toegevoegd.");
                }

                // Voeg TacticsTargets toe als ze niet bestaan
                if (!context.TacticsTargets.Any())
                {
                    Console.WriteLine("TacticsTargets worden toegevoegd.");
                    context.TacticsTargets.AddRange(
                        new TacticsTarget { TacticsTargetId = 1, Value = 10, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 2, Value = 11, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 3, Value = 12, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 4, Value = 13, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 5, Value = 14, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 6, Value = 15, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 7, Value = 16, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 8, Value = 17, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 9, Value = 18, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 10, Value = 19, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 11, Value = 20, HitsRequired = 3, HitsMade = 0, TacticsId = 3 },
                        new TacticsTarget { TacticsTargetId = 12, Value = 25, HitsRequired = 3, HitsMade = 0, TacticsId = 3 }
                    );
                    context.SaveChanges();
                    Console.WriteLine("TacticsTargets succesvol toegevoegd.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout tijdens AddDefaultData: {ex.Message}");
            }
        }
    }
}
