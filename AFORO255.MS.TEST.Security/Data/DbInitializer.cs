using AFORO255.MS.TEST.Security.Persistences;

namespace AFORO255.MS.TEST.Security.Data;

public class DbInitializer
{
    public static void Initialize(ContextDatabase context)
    {
        context.Database.EnsureCreated();

        if (context.Access.Any()) return;

        var orders = new Models.Access[]
        {
                new Models.Access{Fullname="Usuario Aforo255",Username="aforo255",Password="123456"},
                new Models.Access{Fullname="Cesar",Username="cceron",Password="123456"},
                new Models.Access{Fullname="Leonel Messi",Username="lmessi",Password="123"},
        };
        foreach (Models.Access s in orders)
        {
            context.Access.Add(s);
        }
        context.SaveChanges();
    }
}
