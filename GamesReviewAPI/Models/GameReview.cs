using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesReviewAPI.Models
{
    public class GameReview
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
