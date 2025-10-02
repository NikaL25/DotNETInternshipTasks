namespace DotNETInternshipTasksApp.Task02_CoinSplitter
{
    public static class CoinSplitter
    {
        public static int MinSplit(int amount)
        {
            int[] coins = { 50, 20, 10, 5, 1 };
            int count = 0;

            foreach (int coin in coins)
            {
                count += amount / coin;
                amount %= coin;
            }

            return count;
        }
    }
}
