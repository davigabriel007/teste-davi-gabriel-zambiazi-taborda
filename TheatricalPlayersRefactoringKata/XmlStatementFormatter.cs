using System.Collections.Generic;
using System.Xml.Linq;
using TheatricalPlayersRefactoringKata;

public class XmlStatementFormatter : IStatementFormatter
{
    public string Format(Invoice invoice, Dictionary<string, Play> plays)
    {
        var invoiceElement = new XElement("Invoice",
            new XElement("Customer", invoice.Customer),
            new XElement("TotalAmount", FormatCurrency(CalculateTotalAmount(invoice, plays))),
            new XElement("VolumeCredits", CalculateVolumeCredits(invoice, plays))
        );

        var performancesElement = new XElement("Performances");
        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            var performanceElement = new XElement("Performance",
                new XElement("PlayName", play.Name),
                new XElement("Amount", FormatCurrency(play.GenreCalculator.CalculateAmount(play, perf))),
                new XElement("Audience", perf.Audience)
            );
            performancesElement.Add(performanceElement);
        }

        invoiceElement.Add(performancesElement);
        return invoiceElement.ToString();
    }

    private int CalculateTotalAmount(Invoice invoice, Dictionary<string, Play> plays)
    {
        int totalAmount = 0;
        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            totalAmount += play.GenreCalculator.CalculateAmount(play, perf);
        }
        return totalAmount;
    }

    private int CalculateVolumeCredits(Invoice invoice, Dictionary<string, Play> plays)
    {
        int volumeCredits = 0;
        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            volumeCredits += play.GenreCalculator.CalculateVolumeCredits(perf);
        }
        return volumeCredits;
    }

    private string FormatCurrency(int amount)
    {
        return $"{amount / 100:C}";
    }
}
