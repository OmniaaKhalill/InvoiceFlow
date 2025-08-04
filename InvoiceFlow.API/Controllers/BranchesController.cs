using AutoMapper;
using InvoiceFlow.Application.DTOs.Branch;
using InvoiceFlow.Application.DTOs.Item;
using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Application.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchRepo _ibranchRepo;

        private readonly IMapper _mapper;

        public BranchesController(IBranchRepo iBranchRepo, IMapper mapper)
        {
            _ibranchRepo = iBranchRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var items = await _ibranchRepo.GetAllAsync();
            var result = _mapper.Map<List<BranchDetailsDto>>(items);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var branch = await _ibranchRepo.GetAsync(id);
            if (branch == null) return NotFound();
            var result = _mapper.Map<BranchDetailsDto>(branch);

            return Ok(result);
        }
    }
}
