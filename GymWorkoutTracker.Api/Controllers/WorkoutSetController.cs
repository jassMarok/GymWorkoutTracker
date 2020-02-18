using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymWorkoutTracker.Api.Models;
using GymWorkoutTracker.Api.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult GetWorkoutById(Guid id)
        {
            var set = _workoutSetRepository.GetWorkoutSetById(id);
            if (set == null)
            {
                return NotFound();
            }
            return Ok(set);
        }

        [HttpGet("exercise/{id}")]
        public IActionResult GetWorkOutSetsByExerciseId(Guid id)
        {
            var sets = _workoutSetRepository.GetWorkoutSetsByExercise(id);
            
            if (sets == null)
            {
                return NotFound();
            }

            return Ok(sets);
        }

        [HttpPost]
        public IActionResult AddNewWorkoutSet([FromBody]WorkoutSet workoutSet)
        {
            if (workoutSet == null)
            {
                return BadRequest();
            }

            _workoutSetRepository.AddWorkoutSet(workoutSet);
            return Ok(workoutSet);
        }

        [HttpPut]
        public IActionResult UpdateWorkoutSet(WorkoutSet workoutSet)
        {
            if (workoutSet == null || workoutSet.Id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                _workoutSetRepository.EditWorkoutSet(workoutSet);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Ok(workoutSet);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveWorkoutSet(Guid id)
        {
            var set = _workoutSetRepository.GetWorkoutSetById(id);
            if (set == null)
            {
                return NotFound();
            }
            _workoutSetRepository.RemoveWorkoutSet(set);
            return Ok();
        }
    }
}
