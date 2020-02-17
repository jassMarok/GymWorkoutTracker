using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymWorkoutTracker.Api.Models;

namespace GymWorkoutTracker.Api.Repos
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly AppDbContext _context;
        public ExerciseRepository(AppDbContext _context)
        {
            this._context = _context;
        }
        public IEnumerable<Exercise> GetAllExercises()
        {
            return _context.Excercises.ToList();
        }

        public Exercise GetExerciseByGuid(Guid guidId)
        {
            return _context.Excercises.FirstOrDefault(x => x.Id == guidId);
        }

        public Exercise AddExercise(Exercise exercise)
        {
            if (exercise == null || exercise.Name == String.Empty)
            {
                throw new ArgumentException("Exercise name not provided!");
            }

            exercise.CreatedAt = DateTime.Now;
            _context.Excercises.Add(exercise);
            _context.SaveChanges();

            return exercise;
        }
    }
}
