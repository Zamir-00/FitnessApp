using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApi.DbOperations;
using webApi.ExerciseOperations.GetExercises;

namespace webApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class ExerciseController : ControllerBase
    {
        private readonly FitnessAppDbContext _context;

        public ExerciseController (FitnessAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetExercises(){
            GetExercisesQuery query = new GetExercisesQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public Exercise GetById(int id){
            var exercise = _context.Exercises.Where(exercise => exercise.Id == id).SingleOrDefault();
            return exercise;
        }

        [HttpPost]

        public IActionResult AddExercice([FromBody] Exercise newExercise){
            var exercise = _context.Exercises.SingleOrDefault(x=> x.Name == newExercise.Name);

            if (exercise is not null){
                return BadRequest();
            }
            _context.Exercises.Add(newExercise);
            _context.SaveChanges();
            return Ok();
            

        }

        [HttpPut("{id}")]

        public IActionResult UpdateExercise(int id, [FromBody] Exercise updatedExercise){
            var exercise = _context.Exercises.SingleOrDefault(x=>x.Id == id);

            if(exercise is null)
                return BadRequest();
            exercise.Id = updatedExercise.Id != default ? updatedExercise.Id : exercise.Id;
            exercise.Name = updatedExercise.Name != default ? updatedExercise.Name : exercise.Name;
            exercise.numberOfSessions = updatedExercise.numberOfSessions != default ? updatedExercise.numberOfSessions : exercise.numberOfSessions;
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteExercise(int id){
            var exercise = _context.Exercises.SingleOrDefault(x=>x.Id == id);
            if (exercise is null)
                return BadRequest();
            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
            return Ok();
        }
    }
}

