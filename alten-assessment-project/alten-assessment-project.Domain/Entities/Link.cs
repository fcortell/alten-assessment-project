using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class Link : BaseEntity
    {
        public long SelfId { get; set; }
        public long? PreviousEpisodeId { get; set; }
        public long? NextEpisodeId { get; set; }

        public virtual Episode Self { get; set; }
        public virtual Episode PreviousEpisode { get; set; }
        public virtual Episode NextEpisode { get; set; }
    }
}
