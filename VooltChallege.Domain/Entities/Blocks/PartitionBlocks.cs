using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VooltChallenge.Domain.Entities.Blocks;
public class PartitionBlocks : BaseEntity
{
    public List<WebSiteHeaderBlock>? WebSiteHeaderBlocks { get; set; } = [];
    public List<WebSiteHeroBlock>? WebSiteHeroBlocks { get; set; } = [];
    public List<ServicesBlock>? ServicesBlocks { get; set; } = [];
}
