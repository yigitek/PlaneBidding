using AutoMapper;
using BiddingService.Data;
using BiddingService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiddingService.Controllers;

[ApiController]
[Route("api/biddings")]
public class BiddingsController : ControllerBase
{
    private readonly BiddingDbContext _context;
    private readonly IMapper _mapper;

    public BiddingsController(BiddingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<BiddingDto>>> GetAllBiddings()
    {
        var biddings = await _context.Biddings
            .Include(s => s.Aircraft)
            .OrderBy(s => s.Aircraft.Company)
            .ToListAsync();
        
        return _mapper.Map<List<BiddingDto>>(biddings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BiddingDto>> GetBiddingById(Guid id)
    {
        var bidding = await _context.Biddings
            .Include(s => s.Aircraft)
            .FirstOrDefaultAsync(p => p.Id == id);

        if(bidding == null) return NotFound();

        return _mapper.Map<BiddingDto>(bidding);

    }
}
