
namespace BL.BO;

public class Sale
{
    public int Id { get; init; }
    public int IdProduct { get; set; }
    public int CountForSale { get; set; }
    public double TotalPrice { get; set; }
    public bool NeedClub { get; set; }
    public DateTime StartSale { get; set; }
    public DateTime FinishSale { get; set; }
    public override string ToString() => this.ToStringProperty();

}