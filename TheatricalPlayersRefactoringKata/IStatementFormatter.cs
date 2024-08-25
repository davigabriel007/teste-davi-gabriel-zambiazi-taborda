using System.Collections.Generic;
using TheatricalPlayersRefactoringKata;

public interface IStatementFormatter
{
    string Format(Invoice invoice, Dictionary<string, Play> plays);
}