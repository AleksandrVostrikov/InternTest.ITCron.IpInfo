using InternTest.ITCron.IpInfo.Domain.Models;
using System.Net;

namespace InternTest.ITCron.IpInfo.Domain
{
    public interface IResponseService
    {
        Task<string> AddIPResponse(IpResponse ipInfo);
        Task<string> DeleteIPResponse(string ip);
        Task<List<IpResponse>> GetAllIPResponses();
    }
}