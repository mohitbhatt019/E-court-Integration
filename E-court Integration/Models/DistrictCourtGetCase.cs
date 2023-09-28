namespace E_court_Integration.Models
{
    public class DistrictCourtGetCase
    {
        public string CNR { get; set; } = string.Empty;
        public bool WithBusinessData { get; set; } 
        public bool WithJudgement { get; set; } 
    }
}
