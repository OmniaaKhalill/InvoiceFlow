
using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepo _invoicesRepo;

        public InvoicesController(IInvoiceRepo invoicesRepo)
        {
            _invoicesRepo =invoicesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _invoicesRepo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var invoice = await _invoicesRepo.GetAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceHeader invoice)
        {
    
            var created = await _invoicesRepo.AddAsync(invoice);

            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] InvoiceHeader invoice)
        {
            if (id != invoice.ID) return BadRequest();
            var updated = await _invoicesRepo.UpdateAsync(id, invoice);

            if (updated == null)
            {
                return BadRequest();
            }
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
   

            var isDelted = await _invoicesRepo.DeleteAsync(id);
            if (!isDelted)
            {
                return NotFound("Invoice not found or already deleted.");
            }

            return Ok(new { Message = "Invoice deleted successfully." });
        }
    }
}
