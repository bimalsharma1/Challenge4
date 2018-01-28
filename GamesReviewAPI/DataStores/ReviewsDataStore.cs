using GamesReviewAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesReviewAPI.DataStores
{
    public class ReviewsDataStore
    {
        public static ReviewsDataStore Current { get; } = new ReviewsDataStore();

        public List<Review> Reviews { get; set; }

        public ReviewsDataStore()
        {
            Reviews = new List<Review>()
            {
                new Review() {Code=1, Rating=4},
                new Review() {Code=1, Rating=5},
                new Review() {Code=1, Rating=5},
                new Review() {Code=1, Rating=5},
                new Review() {Code=1, Rating=4},
                new Review() {Code=1, Rating=4},
                new Review() {Code=1, Rating=5},
                new Review() {Code=2, Rating=3},
                new Review() {Code=2, Rating=2},
                new Review() {Code=2, Rating=1},
                new Review() {Code=2, Rating=1},
                new Review() {Code=3, Rating=5},
                new Review() {Code=4, Rating=4},
                new Review() {Code=5, Rating=1},
                new Review() {Code=6, Rating=2},
                new Review() {Code=7, Rating=3},
                new Review() {Code=8, Rating=1}
            };
        }
    }
}
