namespace TheatricalPlayersRefactoringKata;

public class Play
{
    private string _name;
    private int _lines;
    private IGenreCalculator _genreCalculator;

    public string Name { get => _name; set => _name = value; }
    public int Lines { get => _lines; set => _lines = value; }
    public IGenreCalculator GenreCalculator { get => _genreCalculator; set => _genreCalculator = value; }

    public Play(string name, int lines, IGenreCalculator genreCalculator)
    {
        this._name = name;
        this._lines = lines;
        this._genreCalculator = genreCalculator;
    }
}