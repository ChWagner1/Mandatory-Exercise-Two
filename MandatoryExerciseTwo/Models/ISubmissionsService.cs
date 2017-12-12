using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace MandatoryExerciseTwo.Models
{
    public interface ISubmissionsService
    {
        Task<IEnumerable<Submission>> GetAll();
        Task RegisterSubmission(Submission model);
    }
}
