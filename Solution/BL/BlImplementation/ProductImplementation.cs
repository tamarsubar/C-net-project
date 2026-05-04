namespace BL.BlImplementation;

using BL.BO;
using static BL.BO.Tools;
internal class ProductImplementation : BL.BlApi.IProduct
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BL.BO.Product product)
    {
        try { return _dal.Product.Create(product.ToDO()); }
        catch (BlAlreadyExistsException ex) { throw new BL.BO.BlAlreadyExistsException("מוצר קיים", ex); }
    }

    public BL.BO.Product? Read(int id)
    {
        var doProd = _dal.Product.Read(id) ?? throw new BL.BO.BlDoesNotExistException("מוצר לא נמצא");
        var boProd = doProd.ToBO();
        boProd.Sales = _dal.Sale.ReadAll(s => s.IdProduct == id).Select(s => s.ToSaleInProduct()).ToList();
        return boProd;
    }

    public IEnumerable<BL.BO.Product> ReadAll(Func<BL.BO.Product, bool>? filter = null)
    {
        var products = from p in _dal.Product.ReadAll()
                       select p.ToBO();
        return filter == null ? products : products.Where(filter);
    }

    public void Update(BL.BO.Product product)
    {
        try { _dal.Product.Update(product.ToDO()); }
        catch (BlDoesNotExistException ex) { throw new BL.BO.BlDoesNotExistException("מוצר לא נמצא", ex); }
    }

    public void Delete(int id)
    {
        try { _dal.Product.Delete(id); }
        catch (BlDoesNotExistException ex) { throw new BL.BO.BlDoesNotExistException("לא ניתן למחוק", ex); }
    }
}