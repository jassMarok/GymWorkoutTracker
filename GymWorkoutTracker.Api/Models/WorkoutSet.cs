using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWorkoutTracker.Api.Models
{
    public class WorkoutSet
    {
        public Guid Id { get; set; }
        public Guid ExcerciseId { get; set; }
        public Exercise Excercise { get; set; }
        public float Weight { get; set; }
        public int Reps { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
