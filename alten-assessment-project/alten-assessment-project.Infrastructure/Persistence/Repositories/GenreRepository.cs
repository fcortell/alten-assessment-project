﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain.Entities;
using alten_assessment_project.Domain.Repositories;

namespace alten_assessment_project.Infrastructure.Persistence.Repositories
{
    public sealed class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
