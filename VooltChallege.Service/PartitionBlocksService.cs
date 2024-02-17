using VooltChallenge.Domain.Dtos;
using VooltChallenge.Domain.Entities.Blocks;
using VooltChallenge.Domain.Enums;
using VooltChallenge.Infra.Exceptions;
using VooltChallenge.Infra.Repository;
using VooltChallenge.Service.Interfaces;

namespace VooltChallenge.Service;

public class PartitionBlocksService(IRepository<PartitionBlocks> repository) : BaseService<PartitionBlocks>(repository), IPartitionBlocksService
{
    public void Delete(string key, BlockType section)
    {
        var entity = _repository.GetByKey(key) ?? throw new NotFoundException(ErrorCode.NotFound<PartitionBlocks>());

        switch (section)
        {
            case BlockType.WebSiteHeader:
                entity.WebSiteHeaderBlocks = [];
                break;
            case BlockType.WebSiteHero:
                entity.WebSiteHeroBlocks = [];
                break;
            case BlockType.Services:
                entity.ServicesBlocks = [];
                break;
            default:
                throw new NotAcceptableException(ErrorCode.NotAcceptable, "Section is invalid");
        }

        _repository.Save(entity);
    }
    public PartitionBlocks? GetByKey(string key)
    {
        var entity = _repository.GetByKey(key);

        return entity == null ? throw new NotFoundException(ErrorCode.NotFound<PartitionBlocks>()) : _repository.GetByKey(key);
    }
    public PartitionBlocks Create(string key)
    {
        VerifyKey(key);

        var newEntity = new PartitionBlocks {Key = key, ServicesBlocks = [], WebSiteHeaderBlocks = [], WebSiteHeroBlocks = []};
        
        return _repository.Save(newEntity);
    }

    public void Update(PartitionBlockUpdateDto dto)
    {
        var partitionBlocks = (_repository.GetByKey(dto.Key));


        if (partitionBlocks == null)
            throw new NotFoundException(ErrorCode.NotFound<PartitionBlocks>());
        else
        {

            switch (dto.Section)
            {
                case BlockType.WebSiteHeader:
                    ValidateBusinessName(partitionBlocks, dto.WebSiteHeaderBlocks);
                    partitionBlocks.WebSiteHeaderBlocks = dto.WebSiteHeaderBlocks;
                    break;
                case BlockType.WebSiteHero:
                    partitionBlocks.WebSiteHeroBlocks = dto.WebSiteHeroBlocks;
                    break;
                case BlockType.Services:
                    partitionBlocks.ServicesBlocks = dto.ServicesBlocks;
                    break;
                default:
                    throw new NotAcceptableException(ErrorCode.NotAcceptable, "Section is invalid");
            }

            _repository.Save(partitionBlocks);
        }
    }

    private static void ValidateBusinessName(PartitionBlocks? partitionBlocks, List<WebSiteHeaderBlock>? webSiteHeaderBlocks)
    {
        if (partitionBlocks == null || partitionBlocks.WebSiteHeaderBlocks == null || webSiteHeaderBlocks == null) return;

        var invalidsBusinessName = new List<string?>();

        foreach (var webSiteHeaderBlock in webSiteHeaderBlocks)
        {
            if (partitionBlocks.WebSiteHeaderBlocks.Any(block => block.BusinessName == webSiteHeaderBlock.BusinessName && block.Key != webSiteHeaderBlock.Key))
                invalidsBusinessName.Add(webSiteHeaderBlock.BusinessName);            
        }

        if(invalidsBusinessName.Count > 0)
        {
            string businessNames = string.Empty;

            string[] businessNameArray = businessNames.Split(',');
           
            businessNames = string.Join(",", businessNameArray.Take(businessNameArray.Length - 1));

            throw new NotAcceptableException(ErrorCode.NotAcceptable, $"The following business names already exists: {businessNames}");
        }


        
    }
}