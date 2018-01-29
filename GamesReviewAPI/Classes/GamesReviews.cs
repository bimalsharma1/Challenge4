using GamesReviewAPI.DataStores;
using GamesReviewAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace GamesReviewAPI.Classes
{
    public class GamesReviews: Interfaces.IGameReviews
    {
        public IEnumerable<GameReview> GetGamesAndReviews()
        {
            List<GameReview> gamesReview = new List<GameReview>();
            foreach (var game in GamesDataStore.Current.Games)
            {
                gamesReview.Add(GetGameReview(game));
            }
            return gamesReview;
        }

        private static GameReview GetGameReview(Game game)
        {
            return new GameReview
            {
                Code = game.Code,
                Title = game.Title,
                Description = game.Description,
                Rating = GetGameRating(game.Code)
            };

        }

        private static int GetGameRating(int gameCode)
        {
            return (int)ReviewsDataStore.Current.Reviews
                        .Where(r => r.Code == gameCode)
                        .Average(g => g.Rating);
        }
    }
}
