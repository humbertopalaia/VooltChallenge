namespace VooltChallenge.Domain.Entities;
public class WebsiteLink
{
    public required string Link { get; set; }
    public WebSiteLinkSubMenu? SubMenu { get; set; }
}
