using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Dtos.Rating;

namespace api.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; } 
        public string Key { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public int Cover { get; set; }
        public string Subjects { get; set; } = string.Empty;
        public string SubjectPlace { get; set; } = string.Empty;
        public string SubjectTimes { get; set; } = string.Empty;
        public decimal AverageRating {get; set; } 
        public List<RatingDto> Ratings {get; set; }
        public List<CommentDto> Comments {get; set; }
    }
}