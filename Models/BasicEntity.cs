using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace BlazorJob.Models
{
    public interface IBasicEntity
    {
        [Key]
        Guid Id { get; set; }
        DateTime Date { get; set; }
        Guid Author { get; set; }

    }

    public class BasicEntity : IBasicEntity
    {
        [Key]
        public Guid Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public Guid Author { get; set; }

    }

    public class SimpleEntity : BasicEntity
    {
        public string Status { get; set; }
        public string Type { get; set; }
        [Required]
        public string Value { get; set; }
    }

    public sealed class Option : SimpleEntity
    {
        [Required]
        public string Key { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; }

        public static readonly string defaultStatus = "";
        public static readonly string defaultType = "";
    }

    public class Post : SimpleEntity
    {
        public string Slug { get; set; }
        public string Value => Content;

        public List<string> Tags { get; set; }
        public Guid Parent { get; set; }
        public Guid Category { get; set; }
        public Guid Guid { get; set; }

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public DateTime Modified { get; set; }


        public static readonly string[] StatusList = { "draft", "pending", "private", "publish", "future", "trash", "auto-draft", "inherit" };

        public static readonly string[] TypeList = { "post", "page", "attachment" };

        public static readonly string defaultStatus = "draft";
        public static readonly string defaultType = "post";
    }

    public sealed class Meta : SimpleEntity
    {
        [Required]
        public string Key { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; }

        public static readonly string defaultStatus = "";
        public static readonly string defaultType = "";

        public Guid PostId { get; set; }
    }

    public class LogEntity : SimpleEntity
    {
        public int Code;
        public string Message;
        public string Stacktrace;
        public List<string> Tags;

        public Guid ObjectId;
        public string ObjectEntity;
    }

    public interface HTMLDrawableItem
    {
        void DrawHTML();
    }

    public interface IEmitableEntity
    {
        void Create();
        void Update();
        void Modify();
        void Remove();
    }

    public interface IEmitableEntityArray : IEmitableEntity
    {
        void Append();
        void Prepend();

    }

    /// <summary>
    /// ����� ��������� ����� �������� ������ � �������� � �������� ��� ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICascadeIterator<T>
    {

    }

    /// <summary>
    /// ��������� ��� ������ ����� �� ����������� ��� �������
    /// </summary>
    public interface IOperatable
    {

    }

    public interface DT_Query<T1, T2>
    {

    }


    interface IModificator
    {
        // void Create
    }

    enum Z
    {
        Create,
        Update
    }
}