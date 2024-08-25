using TheatricalPlayersRefactoringKata;

public interface IGenreCalculator
{
    int CalculateAmount(Play play, Performance performance);
    int CalculateVolumeCredits(Performance performance);
}