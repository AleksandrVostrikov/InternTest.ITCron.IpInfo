using System.Net;

namespace InternTest.ITCron.IpInfo.Domain.Models
{
    public class IpResponse
    {
        private IpResponse(Guid id, string ip, string city, 
            string region, string country, 
            string loc, string org,
            string postal, string timezone)
        {
            Id = id;
            IP = ip;
            City = city;
            Region = region;
            Country = country;
            Loc = loc;
            Org = org;
            Postal = postal;
            Timezone = timezone;
        }
        private IpResponse() { }

        public Guid Id { get; }
        public string IP { get; } = null!;
        public string? City { get; }
        public string? Region { get; }
        public string? Country { get; }
        public string? Loc { get; }
        public string? Org { get; }
        public string? Postal { get; }
        public string? Timezone { get; }

        public static (IpResponse response, string error) Create(Guid id, string ip, string city,
            string region, string country,
            string loc, string org,
            string postal, string timezone)
        {
            var error = String.Empty;
            if (ip.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Length == 4)
            {
                IPAddress ipAddr;
                if (IPAddress.TryParse(ip, out ipAddr))
                {
                    var ipInfo = new IpResponse(id, ipAddr.ToString(), city, region, country, loc, org, postal, timezone);
                    return (ipInfo, error);
                }
                else error = "ip is not correct";
            }
            else error = "ip is not correct";
            return (new IpResponse(), error);
            
        }
    }
}
