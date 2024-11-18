using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; } 
        public string Key { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int StarRating { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public int PublishYear { get; set; }

        public byte[] Cover { get; set; } = Array.Empty<byte>();
        public string Description { get; set; } = string.Empty;
        public string SubjectPlace { get; set; } = string.Empty;
        public string SubjectTimes { get; set; } = string.Empty;
        public string Subjects { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; } = new List<Comment>();
        
    }
}