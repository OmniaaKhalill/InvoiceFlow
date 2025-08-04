using AutoMapper;
using InvoiceFlow.Application.DTOs.Cashier;
using InvoiceFlow.Application.DTOs.Item;
using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Domain.Entities;
using InvoiceFlow.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly IItemRepo _itemsRepo;

        private readonly IMapper _mapper;

        public ItemsController(IItemRepo itemsRepo, IMapper mapper)
        {
            _itemsRepo = itemsRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var items = await _itemsRepo.GetAllAsync();
            var result = _mapper.Map<List<ItemDetailsDto>>(items);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await _itemsRepo.GetAsync(id);
            if (item == null) return NotFound();
            var result = _mapper.Map<ItemDetailsDto>(item);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemCreateDto ItemDto)
        {

            var Item = _mapper.Map<Item>(ItemDto);


            var created= await _itemsRepo.AddAsync(Item);

            if (created== null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ItemUpdateDto ItemDto)
        {
            if (id != ItemDto.ID) return BadRequest();

            var Item = _mapper.Map<Item>(ItemDto);
          var updated =  await _itemsRepo.UpdateAsync(id, Item);
          
            if (updated == null)
            {
                return BadRequest();
            }
            return Ok(updated);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDelted = await _itemsRepo.DeleteAsync(id);
            if (!isDelted)
            {
                return NotFound ("Item not found or already deleted.");
            }

            return Ok(new { Message = "Item deleted successfully." });
           
        }
    }
}
