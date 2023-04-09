namespace FitPlannerAPI.DTO.Exercises
{
    public class ExercisePost
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
