using E_court_Integration.Models;

namespace E_court_Integration.Services
{
    public interface ICourtService
    {
        Task<string> DistrictCourtGetCase(DistrictCourtGetCase obj);
        Task<string> GetHighCourtPartyName(HighCourtPartyNameModel obj);
        Task<string> GetHighCourtAdvocateName(HighCourtAdvocateNameModel obj);
        Task<string> GetHighCourtCase(HighCourtGetCaseModel obj);
    }
}
