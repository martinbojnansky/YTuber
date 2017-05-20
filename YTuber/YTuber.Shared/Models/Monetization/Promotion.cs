using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YTuber.Models.Monetization
{
    [DataContract]
    public class Promotion
    {
        [DataMember(Name = nameof(Id))]
        public string Id { get; set; }

        [DataMember(Name = nameof(Title))]
        public string Title { get; set; }

        [DataMember(Name = nameof(Link))]
        public string Link { get; set; }
    }
}
