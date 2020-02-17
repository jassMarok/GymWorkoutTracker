using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymWorkoutTracker.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Exercise> Excercises { get; set; }
        public DbSet<WorkoutSet> WorkoutSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Excercise Table
            Guid excerciseGuid1 = Guid.NewGuid();
            Guid excerciseGuid2 = Guid.NewGuid();
            Guid excerciseGuid3 = Guid.NewGuid();

            modelBuilder.Entity<Exercise>().HasData(new Exercise
                {Name = "Pull Ups", CreatedAt = DateTime.Now, Id = excerciseGuid1});
            modelBuilder.Entity<Exercise>().HasData(new Exercise
                { Name = "Lat Pull Down", CreatedAt = DateTime.Now, Id = excerciseGuid2 });
            modelBuilder.Entity<Exercise>().HasData(new Exercise
                { Name = "Face Pulls", CreatedAt = DateTime.Now, Id = excerciseGuid3 });

            //Push Ups Data Seed
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid1,
                Reps = 6,
                Weight = -50,
                TimeStamp = DateTime.Now
            });
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid1,
                Reps = 4,
                Weight = -50,
                TimeStamp = DateTime.Now
            });
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid1,
                Reps = 3,
                Weight = -50,
                TimeStamp = DateTime.Now
            });

            //Exercise Lat Pull Down Seed
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid2,
                Reps = 12,
                Weight = 50,
                TimeStamp = DateTime.Now
            });
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid2,
                Reps = 12,
                Weight = 50,
                TimeStamp = DateTime.Now
            });
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid2,
                Reps = 12,
                Weight = 50,
                TimeStamp = DateTime.Now
            });

            //Face Pulls Data Seed
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid3,
                Reps = 6,
                Weight = 20,
                TimeStamp = DateTime.Now
            });
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid3,
                Reps = 6,
                Weight = 20,
                TimeStamp = DateTime.Now
            });
            modelBuilder.Entity<WorkoutSet>().HasData(new WorkoutSet
            {
                Id = Guid.NewGuid(),
                ExcerciseId = excerciseGuid3,
                Reps = 6,
                Weight = 20,
                TimeStamp = DateTime.Now
            });
        }
    }
}
