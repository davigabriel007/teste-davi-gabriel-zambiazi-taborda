using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TheatricalPlayersRefactoringKata.Data;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Services
{
    public class ProcessingService
    {
        private readonly ApplicationDbContext _context;

        public ProcessingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ProcessInvoiceAsync(Invoice invoice)
        {
            // Enfileira o trabalho de processamento
            await Task.Run(() => SaveInvoiceToDatabase(invoice));
            await Task.Run(() => GenerateXml(invoice));
        }

        private void SaveInvoiceToDatabase(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        private void GenerateXml(Invoice invoice)
        {
            var serializer = new XmlSerializer(typeof(Invoice));
            using var writer = new StreamWriter($"./GeneratedInvoices/{invoice.Customer}_invoice.xml");
            serializer.Serialize(writer, invoice);
        }
    }
}