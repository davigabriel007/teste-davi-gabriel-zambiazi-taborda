using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Data;
using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Services;

namespace TheatricalPlayersRefactoringKata.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly ProcessingService _processingService;

        public InvoicesController(ProcessingService processingService)
        {
            _processingService = processingService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessInvoice([FromBody] Invoice invoice)
        {
            if (invoice == null)
                return BadRequest();

            await _processingService.ProcessInvoiceAsync(invoice);
            return Ok("Invoice processed successfully.");
        }
    }
}