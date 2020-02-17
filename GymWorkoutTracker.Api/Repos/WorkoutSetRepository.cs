using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymWorkoutTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GymWorkoutTracker.Api.Repos
{
    public class WorkoutSetRepository:IWorkoutSetRepository
    {
        private readonly AppDbContext _appDbContext;

        public WorkoutSetRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<WorkoutSet> GetAllSets()
        {
            return _appDbContext.WorkoutSets.Include(x=>x.Excercise);
        }

        public WorkoutSet GetWorkoutSetById(Guid guid)
        {
            return _appDbContext.WorkoutSets
                .Include(x=>x.Excercise)
                .FirstOrDefault(x => x.Id == guid);
        }

        public IEnumerable<WorkoutSet> GetWorkoutSetsByExercise(Guid exerciseGuid)
        {
            return _appDbContext.WorkoutSets.Where(x => x.ExcerciseId == exerciseGuid).Include(x => x.Excercise);
        }

        public WorkoutSet AddWorkoutSet(WorkoutSet workoutSet)
        {
            _appDbContext.WorkoutSets.Add(workoutSet);
            _appDbContext.SaveChanges();

            var newWorkOutSet = _appDbContext.WorkoutSets
                .Where(x => x.Id == workoutSet.Id)
                .Include(x => x.Excercise)
                .FirstOrDefault();
            return newWorkOutSet;
        }

        public void RemoveWorkoutSet(WorkoutSet workoutSet)
        {

            _appDbContext.WorkoutSets.Remove(workoutSet);
            _appDbContext.SaveChanges();
        }

        public WorkoutSet EditWorkoutSet(WorkoutSet workoutSet)
        {
            var update = _appDbContext.WorkoutSets.FirstOrDefault(x => x.Id == workoutSet.Id);
            if (update == null)
            {
                throw new InvalidOperationException("Cannot find set to be updated!");
            }
            update.Reps = workoutSet.Reps;
            update.Weight = workoutSet.Weight;
            _appDbContext.SaveChanges();

            var retrieve = _appDbContext.WorkoutSets
                .Include(x=>x.Excercise)
                .FirstOrDefault(x => x.Id == update.Id);
            
            return retrieve;
        }
    }
}
