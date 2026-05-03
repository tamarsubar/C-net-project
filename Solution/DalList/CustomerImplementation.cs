
using DalApi;
using DO;
using static Dal.DalExceptions;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer cus)
    {

        if (DataSource.customers.Any(c => c.Id == cus.Id))
        {

            throw new DalExceptionExist(" The customer already exists in the system. ");
        }
        DataSource.customers.Add(cus);
        return cus.Id;
    }
    public void Update(Customer cus)
    {
        var exist = DataSource.customers.FirstOrDefault(c => c.Id == cus.Id);

        if (exist != null)
        {

            DataSource.customers.Remove(exist);
            DataSource.customers.Add(cus);
            return;
        }
        throw new DalExceptionNotExist("The customer does not exist in the system.");
    }
    public Customer Read(int id)
    {
        var exist = DataSource.customers.FirstOrDefault(c => c.Id == id);

        if (exist != null)
        {
            return exist;
        }
        throw new DalExceptionNotExist("The customer does not exist in the system.");
    }
    public Customer Read(Func<Customer, bool> filter)
    {
        return DataSource.customers.FirstOrDefault(filter);
    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.customers.ToList();
        return DataSource.customers.Where(filter).ToList();
    }

    public void Delete(int id)
    {

        var exist = DataSource.customers.FirstOrDefault(c => c.Id == id);

        if (exist != null)
        {
            DataSource.customers.Remove(exist);
            return;
        }
        throw new DalExceptionNotExist("The customer does not exist in the system.");
    }

}



