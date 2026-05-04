
namespace BL.BO;

public class SaleInProduct
{
    public int Id { get; init; }
    public int CountForSale { get; set; }   
    public double TotalPrice { get; set; } 
    public bool NeedClub { get; set; }

    public override string ToString() => this.ToStringProperty();

}
