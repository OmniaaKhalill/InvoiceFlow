
using InvoiceFlow.Application.DTOs.Invoice;
using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Application.Service.Contract;
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
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceRepo invoicesRepo , IInvoiceService invoiceService)
        {
            _invoicesRepo = invoicesRepo;
            _invoiceService = invoiceService;
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
        public async Task<IActionResult> Post([FromBody] CreateInvoiceHeaderDto dto)
        {
            var createdInvoice = await _invoiceService.CreateInvoiceAsync(dto);
            if (createdInvoice == null)
                return BadRequest("Invalid invoice data or items not found.");

            return Ok(createdInvoice);
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
