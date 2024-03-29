﻿using System.Net;

namespace InternTest.ITCron.IpInfo.DataAcces
{
    public class ResponseEntity
    {
        public Guid Id { get; set; }
        public string IP { get; set; } = null!;
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? Loc { get; set; }
        public string? Org { get; set; }
        public string? Postal { get; set; }
        public string? Timezone { get; set; }
    }
}
