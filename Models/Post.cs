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
        public DateTime Date { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; } = DateTime.Now;

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }

        public int Author { get; set; } = 0;
        public int Parent { get; set; } = 0;

        public string Status { get; set; } = "draft";
        public string Type { get; set; } = "post";


        public static readonly string[] StatusList = { "draft", "pending", "private", "publish", "future", "trash", "auto-draft", "inherit" };

        public static readonly string[] TypeList = {"post", "page", "attachment"};

        public static readonly string defaultStatus = "draft";
        public static readonly string defaultType = "post";
    }
}
