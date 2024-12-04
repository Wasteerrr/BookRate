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
        public int PublishYear { get; set; }
        public int Cover { get; set; } 
        public string SubjectPlace { get; set; } = string.Empty;
        public string SubjectTimes { get; set; } = string.Empty;
        public string Subjects { get; set; } = string.Empty;
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public decimal AverageRating { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Read> Reads { get; set; } = new List<Read>();
        
    }
}