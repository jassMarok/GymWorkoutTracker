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
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var exercises = _exerciseRepository.GetAllExercises();
            return Ok(exercises);
        }

        [HttpGet("{exerciseGuid}")]
        public IActionResult GetExerciseById(Guid exerciseGuid)
        {
            var exercise = _exerciseRepository.GetExerciseByGuid(exerciseGuid);
            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        public IActionResult AddExercise(Exercise exercise)
        {
            if (exercise == null)
            {
                return BadRequest();
            }

            _exerciseRepository.AddExercise(exercise);

            return Ok(exercise);
        }
    }
}
