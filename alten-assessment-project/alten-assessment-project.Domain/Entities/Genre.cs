using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public long ShowId { get; set; }
    }
}
