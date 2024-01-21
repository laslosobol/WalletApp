namespace WalletApp.DAL.Entities;

public class Card
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public decimal Balance { get; set; }
}