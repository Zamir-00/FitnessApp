using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApi.DbOperations;
using webApi.SessionOperations.GetSessions;

namespace webApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class SessionController : ControllerBase
    {
        private readonly FitnessAppDbContext _context;

        public SessionController (FitnessAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSessions(){
            GetSessionsQuery query = new GetSessionsQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{exerciseID}/{id}")]
        public Session GetById(int id, int exerciseID){
            var session = _context.Sessions.Where(session => session.Id == id).Where(session => session.ExerciseId == exerciseID).SingleOrDefault();
            return session;
        }

        [HttpGet("{exerciseID}")]
        public IActionResult GetSessionsByExerciseId(int exerciseID){
            GetSessionsByIDQuery query = new GetSessionsByIDQuery(_context);
            var result = query.Handle(exerciseID);
            return Ok(result);
        }

        [HttpPost]

        public IActionResult AddSession([FromBody] Session newSession){
            var session = _context.Sessions.SingleOrDefault(x=> x.Name == newSession.Name);

            if (session is not null){
                return BadRequest();
            }
            _context.Sessions.Add(newSession);
            _context.SaveChanges();
            return Ok();
            

        }

        [HttpPut("{id}")]

        public IActionResult UpdateSession(int id, [FromBody] Session updatedSession){
            var session = _context.Sessions.SingleOrDefault(x=>x.Id == id);

            if(session is null)
                return BadRequest();
            session.Id = updatedSession.Id != default ? updatedSession.Id : session.Id;
            session.Name = updatedSession.Name != default ? updatedSession.Name : session.Name;
            session.ExerciseId = updatedSession.ExerciseId != default ? updatedSession.ExerciseId : session.ExerciseId;
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id){
            var session = _context.Sessions.SingleOrDefault(x=>x.Id == id);
            if (session is null)
                return BadRequest();
            _context.Sessions.Remove(session);
            _context.SaveChanges();
            return Ok();
        }
    }
}

