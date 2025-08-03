
using AutoMapper;
using InvoiceFlow.Application.DTOs.Cashier;
using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashierFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashiersController : ControllerBase
    {
        private readonly ICashierRepo _CashiersRepo;

        private readonly IMapper _mapper;

        public CashiersController(ICashierRepo CashiersRepo, IMapper mapper)
        {
            _CashiersRepo = CashiersRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var cashiers = await _CashiersRepo.GetAllWithDetailsAsync();
            var result = _mapper.Map<List<CashierDetailsDto>>(cashiers);
            return Ok(result);
        }
         

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var cashier = await _CashiersRepo.GetWithDetailsAsync(id);
            if (cashier == null) return NotFound();
            var result = _mapper.Map<CashierDetailsDto>(cashier);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CashierCreateDto CashierDto)
        {

            var Cashier = _mapper.Map<Cashier>(CashierDto);


            var created= await _CashiersRepo.AddAsync(Cashier);

            if (created== null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CashierUpdateDto CashierDto)
        {
            if (id != CashierDto.Id) return BadRequest();

            var Cashier = _mapper.Map<Cashier>(CashierDto);
          var updated =  await _CashiersRepo.UpdateAsync(id, Cashier);
          
            if (updated == null)
            {
                return BadRequest();
            }
            return Ok(updated);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDelted = await _CashiersRepo.DeleteAsync(id);
            if (!isDelted)
            {
                return NotFound ("Cashier not found or already deleted.");
            }

            return Ok(new { Message = "Cashier deleted successfully." });
           
        }
    }
}