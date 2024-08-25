using TheatricalPlayersRefactoringKata;

public class HistoryCalculator : IGenreCalculator
{
    public int CalculateAmount(Play play, Performance performance)
    {
        var tragedyCalculator = new TragedyCalculator();
        var comedyCalculator = new ComedyCalculator();
        int tragedyAmount = tragedyCalculator.CalculateAmount(play, performance);
        int comedyAmount = comedyCalculator.CalculateAmount(play, performance);
        return tragedyAmount + comedyAmount;
    }

    public int CalculateVolumeCredits(Performance performance)
    {
        var tragedyCalculator = new TragedyCalculator();
        var comedyCalculator = new ComedyCalculator();
        int tragedyCredits = tragedyCalculator.CalculateVolumeCredits(performance);
        int comedyCredits = comedyCalculator.CalculateVolumeCredits(performance);
        return tragedyCredits + comedyCredits;
    }
}
