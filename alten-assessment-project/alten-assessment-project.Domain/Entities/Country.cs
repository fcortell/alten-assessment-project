using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static alten_assessment_project.Domain.Enums.Enums;

namespace alten_assessment_project.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Timezone { get; set; }
    }
}
