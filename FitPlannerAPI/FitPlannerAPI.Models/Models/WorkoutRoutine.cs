using FitPlannerAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPlannerAPI.Models.Models
{
    public class WorkoutRoutine : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Breaktime { get; set; } // seconds

        // Navigation propertied
        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
        public virtual ICollection<UserWorkout> UserWorkouts { get; set; }

    }
}
