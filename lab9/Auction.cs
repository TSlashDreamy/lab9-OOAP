namespace lab9;

class Auction
{
    private readonly List<Observer> observers = new List<Observer>();
    private int currentPrice = 0;

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void StartAuction()
    {
        Console.WriteLine("Auction starts!");
        Console.WriteLine("Initial price: " + currentPrice);

        while (true)
        {
            Console.WriteLine("Current price: " + currentPrice);
            Console.WriteLine("Raise your card if you want to bid higher, or type 'quit' to end the auction:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Auction ended!");
                break;
            }

            if (int.TryParse(input, out int newPrice))
            {
                if (newPrice > currentPrice)
                {
                    currentPrice = newPrice;
                    NotifyObservers("was notified about new bid");
                }
                else
                {
                    Console.WriteLine("Your bid must be higher than the current price.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number or 'quit'.");
            }
        }
    }

    public void PlaceBid(string bidderName, int bidAmount)
    {
        if (bidAmount > currentPrice)
        {
            currentPrice = bidAmount;
        }
        else
        {
            Console.WriteLine("Your bid must be higher than the current price.");
        }
    }

    private void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message, currentPrice);
        }
    }
}
