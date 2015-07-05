﻿namespace Bookie.Core.Domains
{
    using Bookie.Common.Model;
    using Bookie.Core.Interfaces;
    using Bookie.Data.Interfaces;
    using Bookie.Data.Repositories;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookDomain : IBookDomain
    {
        private readonly IBookRepository _bookRepository;

        public BookDomain()
        {
            _bookRepository = new BookRepository();
        }

        public IList<Book> GetAllBooks()
        {
            var s = _bookRepository.GetAll(a => a.BookFile, b => b.CoverImage, c => c.BookHistory, d => d.Publishers, e => e.Authors, f=> f.BookMarks, g=> g.Notes);
            return s;
        }

        public Book GetBookByTitle(string title)
        {
            return _bookRepository.GetAll(a => a.BookFile, b => b.CoverImage, c => c.BookHistory, d => d.Publishers, e => e.Authors, f => f.BookMarks, g=> g.Notes).Single(x=> x.Title.Equals(title));
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetAll(a => a.BookFile, b => b.CoverImage, c => c.BookHistory, d => d.Publishers, e => e.Authors, f => f.BookMarks, g => g.Notes).Single(x => x.Id.Equals(id));
        }

        public void AddBook(params Book[] books)
        {
            if (Exists(books[0].BookFile.FullPathAndFileNameWithExtension))
            {
                return;
            }
            foreach (var bk in books)
            {
                bk.CreatedDateTime = DateTime.Now;
                bk.ModifiedDateTime = DateTime.Now;
            }
            _bookRepository.Add(books);
        }

        public void UpdateBook(params Book[] book)
        {
            foreach (var b in book)
            {
                b.CreatedDateTime = DateTime.Now;
                b.ModifiedDateTime = DateTime.Now;
            }
            _bookRepository.Update(book);
        }

        public void RemoveBook(params Book[] book)
        {
            _bookRepository.Remove(book);
        }

        public bool Exists(string filePath)
        {
            return _bookRepository.Exists(filePath);
        }

        public async Task<IList<Book>> GetAllAsync()
        {
            var s = _bookRepository.GetAllAsync(a => a.BookFile, b => b.CoverImage, c => c.BookHistory, d => d.SourceDirectory, e => e.Publishers, f => f.Authors, g=> g.BookMarks, h=> h.Notes);
            return await s;
        }

        public IList<Book> GetNested()
        {
            return _bookRepository.GetAllNested();
        }
    }
}