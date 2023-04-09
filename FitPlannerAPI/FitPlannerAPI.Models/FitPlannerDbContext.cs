using FitPlannerAPI.Models;
using FitPlannerAPI.Models.Base;
using FitPlannerAPI.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FitPlannerApi.Models;
public class FitPlannerDbContext : DbContext
{
    public FitPlannerDbContext(DbContextOptions<FitPlannerDbContext> options) : base(options) { }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var insertedEntries = this.ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && (
            e.State == EntityState.Added ||
            e.State == EntityState.Modified));

        foreach (var entry in insertedEntries)
        {
            ((BaseEntity)entry.Entity).UpdatedDate = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                ((BaseEntity)entry.Entity).CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Set composite primary keys
        modelBuilder.Entity<MealIngredient>()
            .HasKey(mi => new { mi.MealId, mi.IngredientId });
        modelBuilder.Entity<WorkoutExercise>()
            .HasKey(we => new { we.WorkoutRoutineId, we.ExerciseId });

        // Relationship between MealIngredient and Meal
        modelBuilder.Entity<MealIngredient>()
            .HasOne(mi => mi.Meal)
            .WithMany(m => m.MealIngredients)
            .HasForeignKey(mi => mi.MealId);

        // Relationship between MealIngredient and Ingredient
        modelBuilder.Entity<MealIngredient>()
            .HasOne(mi => mi.Ingredient)
            .WithMany(i => i.MealIngredients)
            .HasForeignKey(mi => mi.IngredientId);

        // Relationship between WorkoutExercise and WorkoutRoutine
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.WorkoutRoutine)
            .WithMany(w => w.WorkoutExercises)
            .HasForeignKey(we => we.WorkoutRoutineId);

        // Relationship between WorkoutExercise and WorkoutRoutine
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseId);
    }

    public DbSet<WorkoutRoutine> WorkoutRoutines { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<MealIngredient> MealIngredients { get; set; }
}
