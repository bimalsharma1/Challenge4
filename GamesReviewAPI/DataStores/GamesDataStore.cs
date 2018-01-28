using GamesReviewAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesReviewAPI.DataStores
{
    public class GamesDataStore
    {
        public static GamesDataStore Current { get; } = new GamesDataStore();

        public List<Game> Games { get; set; }

        public GamesDataStore()
        {
            Games = new List<Game>()
            {
                new Game() {Code=1, Title="World of warcraft",Description="Warcraft"},
                new Game() {Code=2, Title="League of legends",Description="Legends"},
                new Game() {Code=3, Title="Final Fantasy",Description="Description of final fantasy"},
                new Game() {Code=4, Title="Doom",Description="Works on all consoles"},
                new Game() {Code=5, Title="FIFA soccer",Description="FIFA soccer"},
                new Game() {Code=6, Title="Splatoon2",Description="Kids game"},
                new Game() {Code=7, Title="Call of Duty",Description="WWII"},
                new Game() {Code=8, Title="Rugby League",Description="Aussie rugby league players"}
            };
        }
    }
}
