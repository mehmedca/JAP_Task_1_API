﻿using JAP.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.Models
{
    public class MovieModel : DeleteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<ActorModel> Cast { get; set; }
        public ICollection<RatingModel> MovieRatings { get; set; }
    }
}
