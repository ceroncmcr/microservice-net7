using AFORO255.MS.TEST.Security.Models;
using AFORO255.MS.TEST.Security.Persistences;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Security.Services;

public class AccessService : IAccessService
{
    private readonly ContextDatabase _contextDatabase;

    public AccessService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;   

    public IEnumerable<Access> GetAll() => _contextDatabase.Access.ToList();

    public bool Validate(string userName, string password)
    {
        var access = _contextDatabase.Access.FirstOrDefault(x => x.Username == userName && x.Password == password);
        if (access is not null) return true;
        return false;
    }
}
