namespace WalletApp.DAL.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CardId { get; set; }
    public Card Card { get; set; }
    public int Type { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }
    public bool IsPending { get; set; }
    public string AuthorizedUser { get; set; }
    public string Icon { get; set; }
    public DateTime CreatedAt { get; set; }
}