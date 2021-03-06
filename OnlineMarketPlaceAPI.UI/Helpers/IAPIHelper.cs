using OnlineMarketPlaceAPI.UI.Models;
using System.Threading.Tasks;

namespace OnlineMarketPlaceAPI.UI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}