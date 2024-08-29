using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class Episode : BaseEntity
    {
        public Uri Href { get; set; }
        public string Name { get; set; }
    }
}
