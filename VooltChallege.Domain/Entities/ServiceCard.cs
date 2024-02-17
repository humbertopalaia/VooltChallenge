namespace VooltChallenge.Domain.Entities;
public class ServiceCard
{
    public required string ServiceName { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public required CtaButton CtaButton { get; set; }
}
