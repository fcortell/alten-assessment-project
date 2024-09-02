using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain.Entities
{
    public class Show : BaseEntity
    {
        public string? Url { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Language { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public string? Status { get; set; }
        public long? Runtime { get; set; }
        public long AverageRuntime { get; set; }
        public string? Premiered { get; set; }
        public string? Ended { get; set; }
        public string? OfficialSite { get; set; }
        public long? ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public long? RatingId { get; set; }
        public virtual Rating Rating { get; set; }
        public long? Weight { get; set; }
        public long? NetworkId { get; set; }
        public virtual Network Network { get; set; }
        public long? WebChannelId { get; set; }
        public virtual WebChannel WebChannel { get; set; }
        public long? ExternalId { get; set; }
        public virtual External External { get; set; }
        public long? ImageId { get; set; }
        public virtual Image Image { get; set; }
        public string? Summary { get; set; }
        public long Updated { get; set; }
        public long? LinkId { get; set; }
        public virtual Link Link { get; set; }
    }
}
