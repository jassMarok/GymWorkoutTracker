using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymWorkoutTracker.Api.Models;
using GymWorkoutTracker.Api.Repos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymWorkoutTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutSetController : Controller
    {
        private readonly IWorkoutSetRepository _workoutSetRepository;

        public WorkoutSetController(IWorkoutSetRepository workoutSetRepository)
        {
            _workoutSetRepository = workoutSetRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var sets = _workoutSetRepository.GetAllSets();
            return Ok(sets);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkOutSetsById(Guid id)
        {
            var setsByGuid = _workoutSetRepository.GetWorkoutSetsByExercise(id);
            return Ok(setsByGuid);
        }

        [HttpPut]
        public IActionResult UpdateWorkoutSet(WorkoutSet workoutSet)
        {
            _workoutSetRepository.EditWorkoutSet(workoutSet);
            return Ok(workoutSet);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveWorkoutSet(Guid id)
        {
            _workoutSetRepository.RemoveWorkoutSet(id);
            return Ok();
        }
    }
}
