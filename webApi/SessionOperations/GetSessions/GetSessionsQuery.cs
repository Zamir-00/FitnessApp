using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApi.DbOperations;

namespace webApi.SessionOperations.GetSessions
{
    public class GetSessionsQuery
    {
        private readonly FitnessAppDbContext _dbContext;
        public GetSessionsQuery(FitnessAppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<SessionsViewModel> Handle()
        {
            var sessionList = _dbContext.Sessions.OrderBy(x=> x.Id).ToList<Session>();
            List<SessionsViewModel> vm = new List<SessionsViewModel>();
            foreach (var session in sessionList)
            {
                vm.Add(new SessionsViewModel(){
                    Name = session.Name,
                    sessionThumbNail = session.sessionThumbNail
                }
                );
            }
            return vm;
        }
    }

    public class SessionsViewModel
    {
        public string Name {get; set; }

        public string sessionThumbNail {get; set; }


    }
}