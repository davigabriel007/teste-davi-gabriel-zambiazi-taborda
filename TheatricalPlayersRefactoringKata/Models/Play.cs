using System;

namespace TheatricalPlayersRefactoringKata.Models
{
    public class Play
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public IGenreCalculator GenreCalculator { get; set; }

        public Play(string name, int cost, IGenreCalculator genreCalculator)
        {
            Name = name;
            Cost = cost;
            GenreCalculator = genreCalculator;
        }
    }
}