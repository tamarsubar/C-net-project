using BL.BO;

namespace BL.BlApi;

public interface ISale
{
    int Create(Sale sale);
    Sale? Read(int id);
    IEnumerable<Sale> ReadAll(Func<Sale, bool>? filter = null);
    void Update(Sale sale);
    void Delete(int id);
}


