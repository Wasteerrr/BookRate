using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Book
{
    public class UpdateBookRequestDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Klucz nie może być dłuższy niż 20 znaków")]
        public string Key { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "Tytuł nie może być dłuższy niż 50 znaków")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Autor nie może być dłuższy niż 100 znaków")]
        public string Author { get; set; } = string.Empty;
        [Required]
        [Range(0,5)]
        public int StarRating { get; set; }
        [Required]
        [Range(0,3000)]
        public int PublishYear { get; set; }
    }
}