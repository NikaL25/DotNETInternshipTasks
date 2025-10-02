namespace DotNETInternshipTasksApp.Task03_MissingNumber
{
    public static class MissingNumberFinder
    {
        public static int NotContains(int[] array)
        {
            HashSet<int> numbers = new HashSet<int>(array);
            int i = 1;
            while (true)
            {
                if (!numbers.Contains(i))
                    return i;
                i++;
            }
        }
    }
}
