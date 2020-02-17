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
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var exercises = _exerciseRepository.GetAllExercises();
            return Ok(exercises);
        }

        public IActionResult AddExercise(Exercise exercise)
        {
            try
            {
                _exerciseRepository.AddExercise(exercise);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }

            return Ok(exercise);
        }
    }
}
