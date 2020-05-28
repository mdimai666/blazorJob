using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorJob.Models
{
    /// <summary>
    /// Ёто просто элементы типа теги или элемент категории из дерева, они просто есть и с id
    /// ќно структурируетс€ через term_taxonomy
    /// </summary>
    [Serializable]
    public class WpTerm
    {

        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug{ get; set; }
    }
}
