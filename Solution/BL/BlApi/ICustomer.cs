using BL.BO;

namespace BL.BlApi;

public interface ICustomer
{
    int Create(Customer customer);
    Customer? Read(int id);
    IEnumerable<Customer> ReadAll(Func<Customer, bool>? filter = null);
    void Update(Customer customer);
    void Delete(int id);
}