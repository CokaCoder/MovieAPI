using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Interfaces
{
    public interface IMoviesRepo
    {
        public bool SaveChanges();

        //Returns all metadata for given movie id.
        public IEnumerable<MovieModel> GetMovieMetadataById(int id);

        //Returns viewing stats for all movies.
        public IEnumerable<MovieStatsModel> GetAllMovieViewingStats();

        //Saves a new piece of metadata.
        public void CreateMovie(MovieModel cmd);
    }
}
