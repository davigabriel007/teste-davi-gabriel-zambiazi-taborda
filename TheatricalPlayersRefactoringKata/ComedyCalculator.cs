using System;
using TheatricalPlayersRefactoringKata;

public class ComedyCalculator : IGenreCalculator
{
    public int CalculateAmount(Play play, Performance performance)
    {
        int lines = Math.Clamp(play.Lines, 1000, 4000);
        int thisAmount = lines * 10;
        thisAmount += 300 * performance.Audience;
        if (performance.Audience > 20)
        {
            thisAmount += 10000 + 500 * (performance.Audience - 20);
        }
        return thisAmount;
    }

    public int CalculateVolumeCredits(Performance performance)
    {
        int credits = Math.Max(performance.Audience - 30, 0);
        credits += (int)Math.Floor((decimal)performance.Audience / 5);
        return credits;
    }
}