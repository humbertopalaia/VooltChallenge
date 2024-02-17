using VooltChallenge.Domain.Enums;

namespace VooltChallenge.Domain.Entities;
public class CtaButton
{
    public CtaButtonType Type { get; set; }
    public required string Value { get; set; }
}