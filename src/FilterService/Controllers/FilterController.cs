using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;

namespace FilterService;

[ApiController]
[Route("api/filter")]
public class FilterController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Bidding>>> FilterBiddings([FromQuery]FilterParams filterParams)
    {
        var query = DB.PagedSearch<Bidding, Bidding>();

        query.Sort(p => p.Ascending(b => b.Company));

        if(!string.IsNullOrEmpty(filterParams.FilterQuery))
        {
            query.Match(Search.Full, filterParams.FilterQuery).SortByTextScore();
        }

        query = filterParams.OrderBy switch
        {
            "company" => query.Sort(p => p.Ascending(q => q.Company)),
            "new" => query.Sort(p => p.Descending(q => q.Created)),
            _ => query.Sort(p => p.Ascending(q => q.BiddingEnd))
        };

        query = filterParams.FilterBy switch
        {
            "finished" => query.Match(p => p.BiddingEnd < DateTime.UtcNow),
            "endingSoon" => query.Match(p => p.BiddingEnd < DateTime.UtcNow.AddHours(8)
                && p.BiddingEnd > DateTime.UtcNow),
            _ => query.Match(p => p.BiddingEnd > DateTime.UtcNow)
        };

        if(!string.IsNullOrEmpty(filterParams.Vendor))
        {
            query.Match(p => p.Vendor == filterParams.Vendor);
        }

        if(!string.IsNullOrEmpty(filterParams.WinningBidder))
        {
            query.Match(p => p.WinningBidder == filterParams.WinningBidder);
        }

        query.PageNumber(filterParams.PageNr);
        query.PageSize(filterParams.PageSize);

        var res = await query.ExecuteAsync();

        return Ok(new
        {
            results = res.Results,
            pageCount = res.PageCount,
            totalCount = res.TotalCount
        });
    }
}
