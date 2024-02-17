using VooltChallenge.Domain.Dtos;
using VooltChallenge.Domain.Entities.Blocks;
using VooltChallenge.Domain.Enums;

namespace VooltChallenge.Service.Interfaces;
public interface IPartitionBlocksService
{
    public PartitionBlocks? GetByKey(string key);

    public PartitionBlocks Create(string key);
    public void Update(PartitionBlockUpdateDto dto);
    public void Delete(string key, BlockType section);
}
