using InternTest.ITCron.IpInfo.Domain;
using InternTest.ITCron.IpInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace InternTest.ITCron.IpInfo.DataAcces.Repositories
{
    public class ResponsesRepository : IResponsesRepository
    {
        private readonly RsponseDbContext _responseDbContext;

        public ResponsesRepository(RsponseDbContext responseDbContext)
        {
            _responseDbContext = responseDbContext;
        }

        public async Task<List<IpResponse>> GetAll()
        {
            var responseEntities = await _responseDbContext.Responses
                .AsNoTracking()
                .ToListAsync();

            return responseEntities.Select(ip => IpResponse.Create(ip.Id, ip.IP, ip.City, ip.Region,
                ip.Country, ip.Loc, ip.Org, ip.Postal, ip.Timezone).response).ToList();
        }

        public async Task<string> Create(IpResponse response)
        {
            var responseEntity = new ResponseEntity
            {
                Id = response.Id,
                IP = response.IP,
                City = response.City,
                Region = response.Region,
                Country = response.Country,
                Loc = response.Loc,
                Org = response.Org,
                Postal = response.Postal,
                Timezone = response.Timezone
            };
            if (!_responseDbContext.Responses.Any(x => x.IP == response.IP))
            {
                await _responseDbContext.Responses.AddAsync(responseEntity);
                await _responseDbContext.SaveChangesAsync();
            }
            return responseEntity.IP;
        }

        public async Task<string> Delete(string ip)
        {
            await _responseDbContext.Responses
                .Where(x => x.IP == ip)
                .ExecuteDeleteAsync();
            return ip;
        }
    }
}
