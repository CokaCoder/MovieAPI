using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Interfaces;
using MovieAPI.Models;
using MovieAPI.Repositories;

namespace MovieAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMoviesRepo _mockRepo;

        public MoviesController(IMoviesRepo repository)
        {
            _mockRepo = repository;
        }

        //this will respond to an HTTP "GET" request with an id. Returns all metadata for a given movie id.
        //EG: http://localhost:51146/api/Movies/5
        [HttpGet("{id}", Name ="GetMovieMetadataById")]
        public ActionResult<IEnumerable<MovieModel>> GetMovieMetadataById(int id)
        {
            var movies = _mockRepo.GetMovieMetadataById(id);
            return Ok(movies);
        }

        //this will respond to an HTTP "GET" request. Returns the viewing statistics for all movies. (combines both lists.)
        //EG: http://localhost:51146/api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieStatsModel>> GetAllMovieMetadata()
        {
            var movies = _mockRepo.GetAllMovieViewingStats();
            return Ok(movies);
        }

        //this will respond to an HTTP "POST" request
        //EG: http://localhost:51146/api/Movies
        [HttpPost]
        public ActionResult<MovieModel> CreateMovie(MovieModel movieModel)
        {
            _mockRepo.CreateMovie(movieModel);
            _mockRepo.SaveChanges();   

            return CreatedAtRoute(nameof(GetMovieMetadataById), new { Id = movieModel.Id }, movieModel);
        }

    }
}
