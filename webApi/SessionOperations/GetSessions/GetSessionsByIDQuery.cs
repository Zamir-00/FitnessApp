using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApi.DbOperations;

namespace webApi.SessionOperations.GetSessions
{
    public class GetSessionsByIDQuery
    {
        private readonly FitnessAppDbContext _dbContext;
        public GetSessionsByIDQuery(FitnessAppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<SessionsbyIDViewModel> Handle(int exerciseID)
        {
            var sessionList = _dbContext.Sessions.Where(x=> x.ExerciseId == exerciseID).OrderBy(x=> x.Id).ToList<Session>();
            List<SessionsbyIDViewModel> vm = new List<SessionsbyIDViewModel>();
            foreach (var session in sessionList)
            {
                vm.Add(new SessionsbyIDViewModel(){
                    Name = session.Name,
                    sessionThumbNail = session.sessionThumbNail
                }
                );
            }
            return vm;
        }
    }

    public class SessionsbyIDViewModel
    {
        public string Name {get; set; }

        public string sessionThumbNail {get; set; }


    }
}