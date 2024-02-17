using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VooltChallenge.Domain.Entities.Blocks;
public class ServicesBlock : BaseBlock
{
    public required string HeadLineText { get; set; }
    public required ServiceCard ServiceCard { get; set; }
}
