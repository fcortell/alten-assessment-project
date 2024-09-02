using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class WebChannel : BaseEntity
    {
        public string Name { get; set; }
        public long? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string? OfficialSite { get; set; }
    }
}
