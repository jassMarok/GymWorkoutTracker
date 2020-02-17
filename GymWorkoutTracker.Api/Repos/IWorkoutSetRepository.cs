using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymWorkoutTracker.Api.Models;

namespace GymWorkoutTracker.Api.Repos
{
    public interface IWorkoutSetRepository
    {
        IEnumerable<WorkoutSet> GetAllSets();
        WorkoutSet GetWorkoutSetById(Guid guid);
        IEnumerable<WorkoutSet> GetWorkoutSetsByExercise(Guid exerciseGuid);
        WorkoutSet AddWorkoutSet(WorkoutSet workoutSet);
        void RemoveWorkoutSet(WorkoutSet workoutSet);
        WorkoutSet EditWorkoutSet(WorkoutSet workoutSet);
    }
}
