using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace MandatoryExerciseTwo.Models
{
    
    public class SubmissionsService : ISubmissionsService
    {
        private readonly Submission submission = new Submission();
        public Task<IEnumerable<Submission>> GetAll()
        {
            return Task.Run(() => submission.RetrieveSubmissionsFromFile().AsEnumerable());
        }

        public Task RegisterSubmission(Submission model)
        {
            submission.AddSubmission(model);
            
                return Task.CompletedTask;
            
            
        }
    }
}
