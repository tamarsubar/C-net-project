

namespace DalApi;

public interface IDal
{
    public ICustomer Customer { get;  }
    public ISale Sale { get; }
    public IProduct Product { get;  }
}
