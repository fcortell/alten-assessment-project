using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    // TODO: Country should be a static table
    public class Country : BaseEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Timezone { get; set; }
    }
}
