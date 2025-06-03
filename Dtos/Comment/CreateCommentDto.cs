using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Tytuł musi się składać z przyjanmniej 5 nazków")]
        [MaxLength(200, ErrorMessage = "Tytuł nie może być duższy niż 200 znaków")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Komentarz musi się składać z przyjanmniej 5 nazków")]
        [MaxLength(300, ErrorMessage = "Komentarz nie może być duższy niż 200 znaków")]
        public string Content { get; set; } = string.Empty;
    }
}