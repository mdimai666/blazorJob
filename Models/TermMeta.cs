using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorJob.Models
{
    [Serializable]
    public class TermMeta
    {

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(WpTermRelationships))]
        public long term_id { get; set; }

        public string meta_key { get; set; }

        public string meta_value { get; set; }
    }
}
