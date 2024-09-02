using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class External : BaseEntity
    {
        public int? Tvrage { get; set; }
        public int? Thetvdb { get; set; }
        public string? Imdb { get; set; }
    }
}
