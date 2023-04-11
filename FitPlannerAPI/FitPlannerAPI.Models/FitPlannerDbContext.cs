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
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });
        modelBuilder.Entity<UserMeal>()
            .HasKey(um => new { um.UserId, um.MealId });
        modelBuilder.Entity<UserWorkout>()
            .HasKey(uw => new { uw.UserId, uw.WorkoutRoutineId });

        // Create unique constraint
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

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

        // Relationship between WorkoutExercise and Exercise
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseId);

        // Relationship between UserRole and User
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        // Relationship between UserRole and Role
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // Relationship between UserMeal and User
        modelBuilder.Entity<UserMeal>()
            .HasOne(um => um.User)
            .WithMany(u => u.UserMeals)
            .HasForeignKey(um => um.UserId);

        // Relationship between UserMeal and Meal
        modelBuilder.Entity<UserMeal>()
            .HasOne(um => um.Meal)
            .WithMany(m => m.UserMeals)
            .HasForeignKey(um => um.MealId);

        // Relationship between UserWorkout and User
        modelBuilder.Entity<UserWorkout>()
            .HasOne(uw => uw.User)
            .WithMany(u => u.UserWorkouts)
            .HasForeignKey(uw => uw.UserId);

        // Relationship between UserWorkout and WorkoutRoutines
        modelBuilder.Entity<UserWorkout>()
            .HasOne(uw => uw.WorkoutRoutine)
            .WithMany(w => w.UserWorkouts)
            .HasForeignKey(uw => uw.WorkoutRoutineId);
    }

    public DbSet<WorkoutRoutine> WorkoutRoutines { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<MealIngredient> MealIngredients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserMeal> UserMeals { get; set; }
    public DbSet<UserWorkout> UserWorkouts { get; set; }
}
