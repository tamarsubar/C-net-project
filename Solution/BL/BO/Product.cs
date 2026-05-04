using BO;

namespace BL.BO;

public class Product
{
    public int Id { get; init; }
    public string Name { get; set; }
    public Enum Category { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public List<SaleInProduct>? Sales { get; set; }
    public override string ToString() => this.ToStringProperty();

}
