using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VooltChallenge.Domain.Dtos;
using VooltChallenge.Domain.Entities.Blocks;
using VooltChallenge.Domain.Enums;
using VooltChallenge.Service.Interfaces;

namespace VooltChallenge.API.Controllers;

[Route("v{version:apiVersion}/blocks")]
[ApiVersion("1.0")]
[ApiController]
public class BlockController(IPartitionBlocksService _partitionBlocksService) : ControllerBase
{
    [HttpGet()]
    public IActionResult Get(string key)
    {
        var entity = _partitionBlocksService.GetByKey(key);

        return Ok(entity);
    }

    [HttpPost()]
    public IActionResult Create([FromBody] PartitionBlockCreateDto dto)
    {       
        var entity = _partitionBlocksService.Create(dto.Key);
        return Created(new Uri($"{Request.Path}/{entity.Key}", UriKind.Relative), entity);
    }

    [HttpPut]
    public IActionResult Update([FromBody] PartitionBlockUpdateDto dto)
    {        
        _partitionBlocksService.Update(dto);

        return NoContent();
    }

    [HttpDelete()]
    public IActionResult Delete(string key, BlockType section)
    {
        _partitionBlocksService.Delete(key, section);
        return NoContent();
    }
}
