using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Medium { get; set; }
        public string Original { get; set; }
    }
}
