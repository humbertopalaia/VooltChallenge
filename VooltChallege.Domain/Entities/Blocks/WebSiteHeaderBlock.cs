using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VooltChallenge.Domain.Enums;

namespace VooltChallenge.Domain.Entities.Blocks;
public class WebSiteHeaderBlock : BaseBlock
{
    public string? BusinessName { get; set; }
    public LogoStatus? Logo { get; set; }
    public NavigationMenu? NavigationMenu { get; set; }
}
