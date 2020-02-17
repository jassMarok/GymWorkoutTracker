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
        IEnumerable<WorkoutSet> GetWorkoutSetsByExercise(Guid exerciseGuid);
        WorkoutSet AddWorkoutSet(WorkoutSet workoutSet);
        void RemoveWorkoutSet(Guid workoutSetId);
        WorkoutSet EditWorkoutSet(WorkoutSet workoutSet);
    }
}
