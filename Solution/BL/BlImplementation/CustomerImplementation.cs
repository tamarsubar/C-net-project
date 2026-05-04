namespace BL.BlImplementation;

using BL.BO;
using static BL.BO.Tools;

internal class CustomerImplementation : BL.BlApi.ICustomer
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BL.BO.Customer customer)
    {
        try { return _dal.Customer.Create(customer.ToDO()); }
        catch ( BlAlreadyExistsException ex) { throw new BL.BO.BlAlreadyExistsException("לקוח קיים", ex); }
    }

    public BL.BO.Customer? Read(int id)
    {
        try { return _dal.Customer.Read(id)?.ToBO(); }
        catch (BlDoesNotExistException ex) { throw new BL.BO.BlDoesNotExistException("לקוח לא נמצא", ex); }
    }

    public IEnumerable<BL.BO.Customer> ReadAll(Func<BL.BO.Customer, bool>? filter = null)
    {
        var all = _dal.Customer.ReadAll().Select(c => c.ToBO());
        return filter == null ? all : all.Where(filter);
    }

    public void Update(BL.BO.Customer customer)
    {
        try { _dal.Customer.Update(customer.ToDO()); }
        catch (BlDoesNotExistException ex) { throw new BL.BO.BlDoesNotExistException("לא ניתן לעדכן", ex); }
    }

    public void Delete(int id)
    {
        try { _dal.Customer.Delete(id); }
        catch (BlDoesNotExistException ex) { throw new BL.BO.BlDoesNotExistException("לא ניתן למחוק", ex); }
    }
}