using System;
using TheatricalPlayersRefactoringKata;

public class TragedyCalculator : IGenreCalculator
{
    public int CalculateAmount(Play play, Performance performance)
    {
        int lines = Math.Clamp(play.Lines, 1000, 4000);
        int thisAmount = lines * 10;
        if (performance.Audience > 30)
        {
            thisAmount += 1000 * (performance.Audience - 30);
        }
        return thisAmount;
    }

    public int CalculateVolumeCredits(Performance performance)
    {
        return Math.Max(performance.Audience - 30, 0);
    }
}