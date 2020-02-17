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

        public IEnumerable<WorkoutSet> GetWorkoutSetsByExercise(Guid exerciseGuid)
        {
            return _appDbContext.WorkoutSets.Where(x => x.ExcerciseId == exerciseGuid).Include(x => x.Excercise);
        }

        public WorkoutSet AddWorkoutSet(WorkoutSet workoutSet)
        {
            _appDbContext.WorkoutSets.Add(workoutSet);
            _appDbContext.SaveChanges();
            return workoutSet;
        }

        public void RemoveWorkoutSet(Guid workoutSetId)
        {
            var workoutSet = _appDbContext.WorkoutSets.FirstOrDefault(x => x.Id == workoutSetId);
            _appDbContext.WorkoutSets.Remove(workoutSet ?? throw new InvalidOperationException("Invalid workout id"));
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
            return update;
        }
    }
}
