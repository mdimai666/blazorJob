using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorJob.Models
{
    [Serializable]
    public class WpTermRelationships
    {

        public long ObjectId { get; set; }
        public long TermId { get; set; }


    }
}
