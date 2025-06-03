using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Rating;
using api.Models;

namespace api.Mappers
{
    public static class RatingMapper
    {
        public static RatingDto ToRatingDto(this Rating ratingModel)
        {
            return new RatingDto
            {
                Id = ratingModel.Id,
                Score = ratingModel.Score,
                CreatedOn = ratingModel.CreatedOn,
                CreatedBy = ratingModel.AppUser?.UserName ?? "Nieznany autor",
                BookId = ratingModel.BookId
            };
        }
        public static Rating ToRatingFromCreate(this CreateRatingDto ratingDto, int bookId)
        {
            return new Rating
            {
                Score = ratingDto.Score,
                BookId = bookId
            };
        }

        public static Rating ToRatingFromUpdate(this UpdateRatingRequestDto ratingDto)
        {
            return new Rating
            {
            Score = ratingDto.Score
            };
        }
    }
}