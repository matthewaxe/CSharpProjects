namespace MeterPulse.Api.DTOs;

public class MeterSummaryDTO
{
    public double Average{ get; set; }
    public double Minimum{ get; set; }
    public double Maximum{ get; set; }
    public int Count{ get; set; }
    public double PercentageFlagged{ get; set; }
}