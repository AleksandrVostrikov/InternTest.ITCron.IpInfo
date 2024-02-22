using InternTest.ITCron.IpInfo.Domain.Models;
using System.Net;

namespace InternTest.ITCron.IpInfo.Domain
{
    public interface IResponsesRepository
    {
        Task<string> Create(IpResponse ipInfo);
        Task<string> Delete(string ip);
        Task<List<IpResponse>> GetAll();
    }
}