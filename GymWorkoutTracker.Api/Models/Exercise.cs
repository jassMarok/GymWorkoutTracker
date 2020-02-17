using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWorkoutTracker.Api.Models
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
