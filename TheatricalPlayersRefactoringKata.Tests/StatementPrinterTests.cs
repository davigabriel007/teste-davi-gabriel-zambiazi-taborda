using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        var plays = new Dictionary<string, Play>();
        plays.Add("hamlet", new Play("Hamlet", 4024, "tragedy"));
        plays.Add("as-like", new Play("As You Like It", 2670, "comedy"));
        plays.Add("othello", new Play("Othello", 3560, "tragedy"));

        Invoice invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40),
            }
        );

        StatementPrinter statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice, plays);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        var plays = new Dictionary<string, Play>
    {
        { "hamlet", new Play("Hamlet", 4024, new TragedyCalculator()) },
        { "as-like", new Play("As You Like It", 2670, new ComedyCalculator()) },
        { "othello", new Play("Othello", 3560, new TragedyCalculator()) },
        { "henry-v", new Play("Henry V", 3227, new HistoryCalculator()) },
        { "john", new Play("King John", 2648, new HistoryCalculator()) },
        { "richard-iii", new Play("Richard III", 3718, new HistoryCalculator()) }
    };

        var invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
            new Performance("hamlet", 55),
            new Performance("as-like", 35),
            new Performance("othello", 40),
            new Performance("henry-v", 20),
            new Performance("john", 39),
            new Performance("richard-iii", 30)
            }
        );

        var formatter = new TextStatementFormatter();
        var statementPrinter = new StatementPrinter(formatter);
        var result = statementPrinter.Print(invoice, plays);

        Approvals.Verify(result);
    }
}
