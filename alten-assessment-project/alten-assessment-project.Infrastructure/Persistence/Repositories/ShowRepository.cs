using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain.Entities;
using alten_assessment_project.Domain.Repositories;

namespace alten_assessment_project.Infrastructure.Persistence.Repositories
{
    public sealed class ShowRepository : GenericRepository<Show>, IShowRepository
    {
        // Add here any methods that you need for the repository, basic CRUD operations are already implemented in the generic repository

        // Access context via DbContext and Entities

        public ShowRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
