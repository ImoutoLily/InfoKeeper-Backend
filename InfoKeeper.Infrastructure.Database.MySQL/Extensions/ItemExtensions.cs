using InfoKeeper.Core.Models;

namespace InfoKeeper.Infrastructure.Database.MySQL.Extensions;

internal static class ItemExtensions
{
    public static bool MatchesQuery(this Item item, string query)
    {
        query = query.ToLower();

        return item.Title.ToLower().Contains(query)
               || item.Content.ToLower().Contains(query);
    }
}