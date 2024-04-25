namespace FilterService;

public class FilterParams
{
    public string FilterQuery { get; set; }
    public int PageNr { get; set; } = 1;
    public int PageSize { get; set; } = 4;
    public string Vendor { get; set; }
    public string WinningBidder { get; set; }
    public string OrderBy { get; set; }
    public string FilterBy { get; set; }
}
