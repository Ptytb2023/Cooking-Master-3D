namespace Player
{
    public interface IWalet
    {
        int Moneay { get; }

        void Add(int money);
        void Take(int money);
    }
}