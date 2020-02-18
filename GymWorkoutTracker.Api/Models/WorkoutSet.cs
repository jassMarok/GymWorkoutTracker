using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymWorkoutTracker.Api.Models
{
    public class WorkoutSet
    {
        public Guid Id { get; set; }
        [Required]
        public Guid? ExcerciseId { get; set; }
        public Exercise Excercise { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public int Reps { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
