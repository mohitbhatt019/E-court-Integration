using E_court_Integration.Models;
using E_court_Integration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_court_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtService;
        public CourtController(ICourtService courtService)
        {
            _courtService = courtService;
        }

        /// <summary>
        /// Get case information from the district court.
        /// </summary>
        [HttpPost("GetDistrictCourt-GetCase")]
        public async Task<IActionResult> GetCase(DistrictCourtGetCase obj)
        {
            try
            {
                var result = await _courtService.DistrictCourtGetCase(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Get party names from the high court.
        /// </summary>
        [HttpPost("GetHighCourt-PartyName")]
        public async Task<IActionResult> GetHighCourtPartyName(HighCourtPartyNameModel obj)
        {
            try
            {
                var result = await _courtService.GetHighCourtPartyName(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");

            }
        }

        /// <summary>
        /// Get advocate names from the high court.
        /// </summary>
        [HttpPost("GetHighCourt-AdvocateName")]
        public async Task<IActionResult> GetHighCourtAdvocateName(HighCourtAdvocateNameModel obj)
        {
            try
            {
                var result = await _courtService.GetHighCourtAdvocateName(obj);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Search for cases in the high court.
        /// </summary>
        [HttpPost("HighCourt-CaseSearch")]
        public async Task<IActionResult> HighCourtGetCase(HighCourtGetCaseModel obj)
        {
            try
            {
                var result = await _courtService.GetHighCourtCase(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
