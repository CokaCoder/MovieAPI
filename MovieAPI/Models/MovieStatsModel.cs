using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{

    public class MovieStatsModel
    {
        public MovieStatsModel()
        {

        }

        public MovieStatsModel(string line)
        {
            var split = line.Split(',');

            MovieId = Convert.ToInt32(split[0]);
            AverageWatchDurationS = split[1];
        }

        //public int Id { get; set; }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public string AverageWatchDurationS { get; set; }

        public int Watches { get; set; }

        public string ReleaseYear { get; set; }

    }
}
