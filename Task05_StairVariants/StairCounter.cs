namespace DotNETInternshipTasksApp.Task05_StairVariants
{
    public static class StairCounter
    {
        public static int CountVariants(int stairCount)
        {
            if (stairCount <= 1) return 1;

            int[] ways = new int[stairCount + 1];
            ways[0] = 1;
            ways[1] = 1;

            for (int i = 2; i <= stairCount; i++)
            {
                ways[i] = ways[i - 1] + ways[i - 2];
            }

            return ways[stairCount];
        }
    }
}
