using AutoMapper;
using BiddingService.Data;
using BiddingService.DTOs;
using BiddingService.Models;
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

        if(bidding == null) 
            return NotFound();

        return _mapper.Map<BiddingDto>(bidding);

    }

    [HttpPost]
    public async Task<ActionResult<BiddingDto>> CreateBidding(CreateBiddingDto biddingDto)
    {
        var bidding = _mapper.Map<Bidding>(biddingDto);
        // ADD CURRENT USER AS VENDOR
        bidding.Vendor = "TestVendor";

        _context.Biddings.Add(bidding);

        var res = await _context.SaveChangesAsync() > 0;
        if(!res) 
            return BadRequest("Could not save changes to Database");

        return CreatedAtAction(nameof(GetBiddingById), 
            new{bidding.Id}, _mapper.Map<BiddingDto>(bidding));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBidding(Guid id, UpdateBiddingDto updatebiddingDto)
    {
        var bidding = await _context.Biddings.Include(s => s.Aircraft)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        if(bidding == null) 
            return NotFound();
        //CHECK VENDOR == USERNAME
        bidding.Aircraft.Company = updatebiddingDto.Company ?? bidding.Aircraft.Company;
        bidding.Aircraft.ModelNo = updatebiddingDto.ModelNo ?? bidding.Aircraft.ModelNo;
        bidding.Aircraft.Colour = updatebiddingDto.Colour ?? bidding.Aircraft.Colour;
        bidding.Aircraft.Milage = updatebiddingDto.Milage ?? bidding.Aircraft.Milage;
        bidding.Aircraft.BuildDate = updatebiddingDto.BuildDate ?? bidding.Aircraft.BuildDate;

        var res = await _context.SaveChangesAsync() > 0;

        if(res) 
            return Ok();

        return BadRequest("Couldn't save changes");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBidding(Guid id)
    {
        var bidding = await _context.Biddings.FindAsync(id);

        if(bidding == null)
            return NotFound();

        _context.Biddings.Remove(bidding);

        var res = await _context.SaveChangesAsync() > 0;

        if(!res)
            return BadRequest("Couldn't delete");

        return Ok();
    }
}
