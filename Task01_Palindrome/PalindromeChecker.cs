namespace DotNETInternshipTasksApp.Task01_Palindrome
{
    public static class PalindromeChecker
    {
        public static bool sPalindrome(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            string clean = text.ToLower().Replace(" ", "");
            int len = clean.Length;

            for (int i = 0; i < len / 2; i++)
            {
                if (clean[i] != clean[len - i - 1])
                    return false;
            }
            return true;
        }
    }
}
