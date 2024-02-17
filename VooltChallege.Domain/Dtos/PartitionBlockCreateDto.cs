using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VooltChallenge.Domain.Enums;

namespace VooltChallenge.Domain.Dtos;
public class PartitionBlockCreateDto
{
    [Required]
    public required string Key { get; set; } 
}
