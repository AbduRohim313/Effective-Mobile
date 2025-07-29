namespace Effective_Mobile.Interfaces;

public interface IRepository
{
    Task<IDictionary<string, List<string>>> Db();
}