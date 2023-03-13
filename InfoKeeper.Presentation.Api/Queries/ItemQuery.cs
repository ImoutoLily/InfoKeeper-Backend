﻿using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.Queries;

[ExtendObjectType(Name = "Query")]
public class ItemQuery
{
    public async Task<List<Item>> GetItemsAsync([Service] IItemService service) 
        => await service.GetAsync();
    
    // TODO: check null conditions
    public async Task<Item?> GetItemAsync([Service] IItemService service, string id) 
        => await service.GetAsync(id);
}