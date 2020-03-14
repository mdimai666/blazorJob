using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorJob.Models
{
    [Serializable]
    public class Post
    {

        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
