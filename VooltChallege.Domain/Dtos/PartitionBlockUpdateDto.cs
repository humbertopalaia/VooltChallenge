using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VooltChallenge.Domain.Entities.Blocks;
using VooltChallenge.Domain.Enums;

namespace VooltChallenge.Domain.Dtos;
public class PartitionBlockUpdateDto : PartitionBlockCreateDto
{
    [Required]
    public required BlockType Section { get; set; }
    public List<WebSiteHeroBlock>? WebSiteHeroBlocks { get; set; } = [];
    public List<WebSiteHeaderBlock>? WebSiteHeaderBlocks{ get; set; } = [];
    public List<ServicesBlock>? ServicesBlocks { get; set; } = [];
}
