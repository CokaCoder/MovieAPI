using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieModel
    {
        public MovieModel()
        {

        }

        public MovieModel(string line)
        {
            var split = line.Split(',');

            Id = Convert.ToInt32(split[0]);
            MovieId = Convert.ToInt32(split[1]);
            Title = split[2];
            Language = split[3];
            Duration = split[4];
            ReleaseYear = split[5];
        }

        public int Id { get; set; }

        public int MovieId { get; set; }

        [Required]
        public string Title  { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string ReleaseYear { get; set; }

    }
}
