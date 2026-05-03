namespace BlImplementation;
using static BO.Tools;
internal class SaleImplementation : BL.BlApi.ISale
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BL.BO.Sale sale)
    {
        try { return _dal.Sale.Create(sale.ToDO()); }
        catch (DO.DalAlreadyExistsException ex) { throw new BL.BO.BlAlreadyExistsException("מבצע קיים", ex); }
    }

    public BL.BO.Sale? Read(int id)
    {
        try { return _dal.Sale.Read(id)?.ToBO(); }
        catch (DO.DalDoesNotExistException ex) { throw new BL.BO.BlDoesNotExistException("מבצע לא נמצא", ex); }
    }

    public IEnumerable<BL.BO.Sale> ReadAll(Func<BL.BO.Sale, bool>? filter = null)
    {
        var sales = _dal.Sale.ReadAll().Select(s => s.ToBO());
        return filter == null ? sales : sales.Where(filter);
    }

    public void Update(BL.BO.Sale sale)
    {
        try { _dal.Sale.Update(sale.ToDO()); }
        catch (DO.DalDoesNotExistException ex) { throw new BL.BO.BlDoesNotExistException("מבצע לא נמצא", ex); }
    }

    public void Delete(int id)
    {
        try { _dal.Sale.Delete(id); }
        catch (DO.DalDoesNotExistException ex) { throw new BL.BO.BlDoesNotExistException("לא ניתן למחוק", ex); }
    }
}