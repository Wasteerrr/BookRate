using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;

namespace api.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; } 
        public string Key { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int StarRating { get; set; }
        public int PublishYear { get; set; }
        public List<CommentDto> Comments {get; set; }
    }
}