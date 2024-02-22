namespace InternTest.ITCron.IpInfo.Contracts
{
    public record IpResponsesResponse(string ip, string city,
            string region, string country,
            string loc, string org,
            string postal, string timezone);

    
}
