using GamesReviewAPI.Models;
using System.Collections.Generic;

namespace GamesReviewAPI.Interfaces
{
    public interface IGameReviews
    {
         IEnumerable<GameReview> GetGamesAndReviews();
    }
}
