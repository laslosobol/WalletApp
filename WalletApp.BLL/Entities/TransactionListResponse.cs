namespace WalletApp.BLL.Entities;

public class TransactionListResponse
{
    public decimal CardBalance { get; set; }
    public decimal Available { get; set; }
    public string DailyPoints { get; set; }
    public List<TransactionDetailResponse> TransactionDetailResponses { get; set; }
}