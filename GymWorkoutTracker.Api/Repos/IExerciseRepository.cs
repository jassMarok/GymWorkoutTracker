using System;
using System.Collections;
using System.Collections.Generic;
using GymWorkoutTracker.Api.Models;

namespace GymWorkoutTracker.Api.Repos
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAllExercises();
        Exercise GetExerciseByGuid(Guid guidId);
        Exercise AddExercise(Exercise exercise);
    }
}
