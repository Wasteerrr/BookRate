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
                PublishYear = bookModel.PublishYear,
                Comments = bookModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Book ToBookFromCreateDto(this CreateBookRequestDto bookDto)
        {
            return new Book
            {
                Key = bookDto.Key,
                Title = bookDto.Title,
                Author = bookDto.Author,
                PublishYear = bookDto.PublishYear
            };
        }

        public static Book ToBookFromBMP(this BMPBook.Doc bmpBook)
        {
            return new Book
            {
                Key = bmpBook.edition_key[0],
                Title = bmpBook.title,
                Author = string.Join(", ", bmpBook.author_name),
                PublishYear = bmpBook.first_publish_year,
                Cover = bmpBook.cover_i,
                Subjects = string.Join(", ", bmpBook.subject),
                SubjectPlace = string.Join(", ", bmpBook.place),
                SubjectTimes = string.Join(", ", bmpBook.time)
            };
        }
    }
}