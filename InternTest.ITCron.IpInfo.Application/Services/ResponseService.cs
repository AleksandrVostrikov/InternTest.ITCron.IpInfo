using InternTest.ITCron.IpInfo.Domain;
using InternTest.ITCron.IpInfo.Domain.Models;
using System.Net;

namespace InternTest.ITCron.IpInfo.Application.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponsesRepository _repository;

        public ResponseService(IResponsesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<IpResponse>> GetAllIPResponses()
        {
            return await _repository.GetAll();
        }

        public async Task<string> AddIPResponse(IpResponse ipInfo)
        {
            return await _repository.Create(ipInfo);
        }

        public async Task<string> DeleteIPResponse(string ip)
        {
            return await _repository.Delete(ip);
        }
    }
}
