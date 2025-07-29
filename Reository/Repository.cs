using Effective_Mobile.Interfaces;

namespace Effective_Mobile.Reository;

public class Repository : IRepository
{
    private Dictionary<string, List<string>> db = new();

    public async Task<IDictionary<string, List<string>>> Db()
    {
        return db;
    }
}