using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace webApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider){
            using (var context = new FitnessAppDbContext(serviceProvider.GetRequiredService<DbContextOptions<FitnessAppDbContext>>()))
            {
                if(context.Exercises.Any())
                {
                    return;
                }

                context.Exercises.AddRange
                (
                    new Exercise{
                        Id = 1,
                        Name = "Yoga",
                        numberOfSessions = 5

                    },
                    new Exercise{
                        Id = 2,
                        Name = "Esneme",
                        numberOfSessions = 5

                    },
                    new Exercise{
                        Id = 3,
                        Name = "Meditasyon",
                        numberOfSessions = 5

                    },
                    new Exercise{
                        Id = 4,
                        Name = "Kardiyo",
                        numberOfSessions = 5

                    }
                );
                
                context.SaveChanges();
                
            }
            using (var context = new FitnessAppDbContext(serviceProvider.GetRequiredService<DbContextOptions<FitnessAppDbContext>>()))
            {
                if(context.Sessions.Any())
                {
                    return;
                }

                context.Sessions.AddRange
                (
                    new Session{
                        Id = 11,
                        ExerciseId = 1,
                        Name = "Yoga-1",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 12,
                        ExerciseId = 1,
                        Name = "Yoga-2",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 13,
                        ExerciseId = 1,
                        Name = "Yoga-3",
                        sessionThumbNail = "",
                        sessionContent = ""
                    },
                    new Session{
                        Id = 14,
                        ExerciseId = 1,
                        Name = "Yoga-4",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 21,
                        ExerciseId = 2,
                        Name = "Esneme-1",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 22,
                        ExerciseId = 2,
                        Name = "Esneme-2",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 23,
                        ExerciseId = 2,
                        Name = "Esneme-3",
                        sessionThumbNail = "",
                        sessionContent = ""
                    },
                    new Session{
                        Id = 24,
                        ExerciseId = 2,
                        Name = "Esneme-4",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 31,
                        ExerciseId = 3,
                        Name = "Meditasyon-1",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 32,
                        ExerciseId = 3,
                        Name = "Meditasyon-2",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 33,
                        ExerciseId = 3,
                        Name = "Meditasyon-3",
                        sessionThumbNail = "",
                        sessionContent = ""
                    },
                    new Session{
                        Id = 34,
                        ExerciseId = 3,
                        Name = "Meditasyon-4",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 41,
                        ExerciseId = 4,
                        Name = "Kardiyo-1",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 42,
                        ExerciseId = 4,
                        Name = "Kardiyo-2",
                        sessionThumbNail = "",
                        sessionContent = ""

                    },
                    new Session{
                        Id = 43,
                        ExerciseId = 4,
                        Name = "Kardiyo-3",
                        sessionThumbNail = "",
                        sessionContent = ""
                    },
                    new Session{
                        Id = 44,
                        ExerciseId = 4,
                        Name = "Kardiyo-4",
                        sessionThumbNail = "",
                        sessionContent = ""

                    }
                );
                
                context.SaveChanges();
                
            }

            using (var context = new FitnessAppDbContext(serviceProvider.GetRequiredService<DbContextOptions<FitnessAppDbContext>>()))
            {
                if(context.Accounts.Any())
                {
                    return;
                }
                context.Accounts.AddRange
                (
                    new Account{
                        accountId = 1,
                        accountName = "mirzasahinkaya@emlakjet.com",
                        password = "cerenatilgan"

                    },
                    new Account{
                        accountId = 2,
                        accountName = "handenurileri@kocholding.com",
                        password = "arcelik"    
                    }  
                );
                context.SaveChanges();
                
            }
            

        } 
    }
}