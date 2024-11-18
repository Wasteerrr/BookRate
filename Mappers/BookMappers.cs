using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Models;

namespace api.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Key = bookModel.Key,
                Title = bookModel.Title,
                Author = bookModel.Author,
                StarRating = bookModel.StarRating,
                PublishYear = bookModel.PublishYear
            };
        }

        public static Book ToBookFromCreateDto(this CreateBookRequestDto bookDto)
        {
            return new Book
            {
                Key = bookDto.Key,
                Title = bookDto.Title,
                Author = bookDto.Author,
                StarRating = bookDto.StarRating,
                PublishYear = bookDto.PublishYear
            };
        }
    }
}