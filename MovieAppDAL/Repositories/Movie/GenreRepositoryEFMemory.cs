﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieAppDAL.Context;
using MovieAppDAL.Entities.Movie;

namespace MovieAppDAL.Repositories.Movie
{
    class GenreRepositoryEFMemory : IRepository<Genre>
    {

        private readonly InMemoryContext _context;
        private static int _id = 1;

        public GenreRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Genre Add(Genre genre)
        {
            genre.Id = _id++;
            _context.Genres.Add(genre);
            return genre;
        }

        public List<Genre> ListAll()
        {
            return _context.Genres.ToList();
        }

        public Genre FindById(int id)
        {
            return _context.Genres.FirstOrDefault(genre => genre.Id == id);
        }

        public Genre Delete(int id)
        {
            var genre = FindById(id);
            _context.Genres.Remove(genre);
            return genre;
        }
    }
}
