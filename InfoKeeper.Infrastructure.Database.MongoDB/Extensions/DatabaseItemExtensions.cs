using InfoKeeper.Infrastructure.Database.MongoDB.Models;

namespace InfoKeeper.Infrastructure.Database.MongoDB.Extensions;

internal static class DatabaseItemExtensions
{
    public static bool MatchesQuery(this DatabaseItem item, string query)
    {
        var lowerQuery = query.ToLower();
    
        return item.Title.ToLower().Contains(lowerQuery) 
               || item.Content.ToLower().Contains(lowerQuery);
    }
}