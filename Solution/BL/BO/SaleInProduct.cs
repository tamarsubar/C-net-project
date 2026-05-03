namespace BO;

public class SaleInProduct
{
	public int Id { get; init; }
	public int DiscountPercent { get; set; }

	public override string ToString() => this.ToStringProperty();
}