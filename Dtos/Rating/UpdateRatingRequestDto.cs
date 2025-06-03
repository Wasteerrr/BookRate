using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Rating
{
    public class UpdateRatingRequestDto
    {
        [Required]
        [Range(0,5)]
        public int Score { get; set; }
    }
}