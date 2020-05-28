using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorJob.Models
{
    /// <summary>
    /// ��� ������ �������� ���� ���� ��� ������� ��������� �� ������, ��� ������ ���� � � id
    /// ��� ��������������� ����� term_taxonomy
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
