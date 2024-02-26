namespace lab9;

class Observer
{
    private readonly string name;
    private readonly Auction auction;

    public Observer(string name, Auction auction)
    {
        this.name = name;
        this.auction = auction;
    }

    public void Update(string message, int currentPrice)
    {
        Random random = new Random();
        int chance = random.Next(0, 101);
        
        Console.WriteLine($"{name}: {message} {currentPrice}");
        if (chance >= 50) 
        {     
            int newPrice = currentPrice + random.Next(10, 101);
            Console.WriteLine($"{name}, decided to bid: {newPrice}");
            auction.PlaceBid(name, newPrice);
        }
        else
        {
            Console.WriteLine($"{name}, decided to pass.");
        }
    }
}
