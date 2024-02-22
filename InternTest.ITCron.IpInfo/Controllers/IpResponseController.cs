using InternTest.ITCron.IpInfo.Contracts;
using InternTest.ITCron.IpInfo.Domain;
using IPinfo.Models;
using IPinfo;
using Microsoft.AspNetCore.Mvc;
using InternTest.ITCron.IpInfo.Domain.Models;
using Microsoft.Extensions.Options;
using InternTest.ITCron.IpInfo.Domain.Infrastructure;

namespace InternTest.ITCron.IpInfo.Controllers
{
    [Route("api/ipinfo")]
    public class IpResponseController : ControllerBase
    {
        private readonly IResponseService _response;
        private readonly IOptions<TokenSettings> _options;

        public IpResponseController(IResponseService response, IOptions<TokenSettings> options)
        {
            _response = response;
            _options = options;
        }

        [HttpGet]
        public async Task<ActionResult<List<IpResponsesResponse>>> GetAllIpResponses()
        {
            var responses = await _response.GetAllIPResponses();
            var result = responses.Select(r => new IpResponsesResponse(r.IP, r.City,
                r.Region, r.Country, r.Loc, r.Org, r.Postal, r.Timezone));

            return Ok(result);
        }

        [HttpPost("{ip}")]
        public async Task<ActionResult<IpResponsesResponse>> AddIpResponse(string ip)
        {
            string token = _options.Value.Token;

            IPinfoClient client = new IPinfoClient.Builder()
              .AccessToken(token)
              .Build();
            IPResponse ipResponse = await client.IPApi.GetDetailsAsync(ip);

            var (response, error) = IpResponse.Create(
                Guid.NewGuid(), ipResponse.IP, 
                ipResponse.City, ipResponse.Region,
                ipResponse.Country, ipResponse.Loc, 
                ipResponse.Org, ipResponse.Postal, ipResponse.Timezone);

            if (!string.IsNullOrEmpty(error)) return BadRequest(error);
            
            await _response.AddIPResponse(response);
            var result = new IpResponsesResponse(response.IP, response.City,
                response.Region, response.Country, response.Loc, response.Org, response.Postal, response.Timezone);
            
            return Ok(result);
        }

        [HttpDelete("delete/{ip}")]
        public async Task<ActionResult<string>> DeleteIpResponse(string ip)
        {
            return Ok(await _response.DeleteIPResponse(ip));
        }
    }
}
