using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace alten_assessment_project.Domain.Entities
{
    public class Self : BaseEntity
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
