using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class Image : BaseEntity
    {
        public Uri Medium { get; set; }
        public Uri Original { get; set; }
    }
}
