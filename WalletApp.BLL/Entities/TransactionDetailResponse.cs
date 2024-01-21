namespace WalletApp.BLL.Entities;

public class TransactionDetailResponse
{
    public string Name{ get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
    public bool IsPending { get; set; }
    public string AuthorizedUser { get; set; }
}