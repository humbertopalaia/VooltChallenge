using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VooltChallenge.Domain.Entities.Blocks;
public class WebSiteHeroBlock : BaseBlock
{
    public required string Description { get; set; }
    public required string HeadLineText { get; set; }
    public required string Image { get; set; }
    public required PositionAlignement ImageAlignement { get; set; }
    public required PositionAlignement ContentAlignment { get; set; }
}

