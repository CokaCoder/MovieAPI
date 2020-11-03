using MovieAPI.Interfaces;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repositories
{
    public class MockMovieRepo : IMoviesRepo
    {

        private readonly List<MovieModel> _MoviesList;
        private readonly List<MovieStatsModel> _MovieStatsList;
        private static List<MovieModel> _database = new List<MovieModel>();

        public MockMovieRepo()
        {
            _MoviesList = File.ReadAllLines("C:\\Users\\jonathan.warner\\Desktop\\movie api challenge\\metadata.csv").Select(line => new MovieModel(line)).Skip(1).ToList();
            _MovieStatsList = File.ReadAllLines("C:\\Users\\jonathan.warner\\Desktop\\movie api challenge\\stats.csv").Select(line => new MovieStatsModel(line)).Skip(1).ToList();
        }

        public void CreateMovie(MovieModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _database.Add(model);
        }

        //Returns all metadata for a given movie id.
        public IEnumerable<MovieModel> GetMovieMetadataById(int id)
        {
            var result = _MoviesList.Where(Id => Id.MovieId == id).ToList();
            return result;
        }

        //Returns viewing stats for all movies.
        public IEnumerable<MovieStatsModel> GetAllMovieViewingStats()
        {
            var resultList = new List<MovieStatsModel>();

            var combinedList = (from movies in _MoviesList 
                         join stats in _MovieStatsList
                         on movies.MovieId equals stats.MovieId
                         select new { movies.MovieId, movies.Title, stats.AverageWatchDurationS, movies.ReleaseYear }).ToList();

            var result = combinedList.GroupBy(x => x.MovieId)
                .Select(x => new {
                    MovieId = x.Key,
                    x.First().Title,
                    x.First().AverageWatchDurationS,
                    watches = x.Count(),
                    x.First().ReleaseYear
                })
                .OrderByDescending(x => x.watches)
                .ThenByDescending(x => x.ReleaseYear)
                .ToList();

            foreach (var item in result)
            {
                var msModel = new MovieStatsModel()
                {
                    MovieId = item.MovieId,
                    Title = item.Title,
                    AverageWatchDurationS = item.AverageWatchDurationS,
                    Watches = item.watches,
                    ReleaseYear = item.ReleaseYear
                };
                resultList.Add(msModel);
            }

            return resultList;
        }

        //Saves a new piece of metadata.
        public bool SaveChanges()
        {
            //would call SaveChanges here on a db context
            return true;
        }
    }
}
