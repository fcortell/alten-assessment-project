using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class External : BaseEntity
    {
        public long Tvrage { get; set; }
        public long? Thetvdb { get; set; }
        public string Imdb { get; set; }
    }
}
