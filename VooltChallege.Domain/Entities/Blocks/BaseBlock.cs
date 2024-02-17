using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VooltChallenge.Domain.Enums;

namespace VooltChallenge.Domain.Entities.Blocks;
public class BaseBlock 
{
    public required string Key { get; set; }
    public required BlockType Type { get; set; }
    public required int Order { get; set; }
    public required CtaButton CtaButton { get; set; }
}
