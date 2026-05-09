namespace BL.BO;


public class Order
{
    public bool IsPreferredCustomer { get; set; } 
    public List<ProductInOrder>? Items { get; set; } 
    public double TotalPrice { get; set; } 
    public override string ToString() => this.ToStringProperty();
}