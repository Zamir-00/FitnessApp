using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApi.DbOperations;

namespace webApi.ExerciseOperations.GetExercises
{
    public class GetExercisesQuery
    {
        private readonly FitnessAppDbContext _dbContext;
        public GetExercisesQuery(FitnessAppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<ExercisesViewModel> Handle()
        {
            var exerciseList = _dbContext.Exercises.OrderBy(x=> x.Id).ToList<Exercise>();
            List<ExercisesViewModel> vm = new List<ExercisesViewModel>();
            foreach (var exercise in exerciseList)
            {
                vm.Add(new ExercisesViewModel(){
                    Name = exercise.Name,
                    numberOfSessions = exercise.numberOfSessions
                }
                );
            }
            return vm;
        }
    }

    public class ExercisesViewModel
    {
        public string Name {get; set; }

        public int numberOfSessions {get; set; }


    }
}