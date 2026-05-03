
using DalApi;
using DO;
using static Dal.DalExceptions;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale s)
    {
        Sale sale = s with { Id = DataSource.Config.SaleCode };

        DataSource.Sales.Add(sale);
        return sale.Id;
    }

    public Sale Read(int id)
    {
        var exist = DataSource.Sales.FirstOrDefault(s => s.Id == id);

        if (exist == null)
            throw new DalExceptionNotExist("The offer does not exist in the system.");
        return exist;
    }
    public Sale Read(Func<Sale, bool> filter)
    {
        return DataSource.Sales.FirstOrDefault(filter);
    }

    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Sales.ToList();
        return DataSource.Sales.Where(filter).ToList();
    }

    public void Delete(int id)
    {

        var exist = DataSource.Sales.FirstOrDefault(s => s.Id == id);

        if (exist == null)
            throw new DalExceptionNotExist("The offer does not exist in the system.");
        DataSource.Sales.Remove(exist);

    }

    public void Update(Sale s)
    {


        var exist = DataSource.Sales.FirstOrDefault(s => s.Id == s.Id);

        if (exist == null)
            throw new DalExceptionNotExist("The offer does not exist in the system.");

        DataSource.Sales.Remove(exist);
        DataSource.Sales.Add(s);
    }

}
