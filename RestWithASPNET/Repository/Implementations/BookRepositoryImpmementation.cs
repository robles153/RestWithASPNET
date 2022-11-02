﻿using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Repository.Implementations
{
    public class BookRepositoryImpmementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImpmementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(b => b.Id == id);
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }

        public Book Update(Book book)
        {
            if (!Exist(book.Id)) return null;
            
            var result = _context.Books.SingleOrDefault(b => b.Id == book.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
               
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public bool Exist(long id)
        {
            return _context.Books.Any(b => b.Id == id);
        }

    

       

        
    }
}
