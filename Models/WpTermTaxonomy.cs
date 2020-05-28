using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorJob.Models
{
    [Serializable]
    public class WpTermTaxonomy
    {

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(WpTerm))]
        public long TermId { get; set; }
        public string Taxonomy { get; set; } //post_type
        public string Description { get; set; }
        public long Parent { get; set; }
        public long Count { get; set; }
    }
}
