using System;
using System.IO;
using System.Threading.Tasks;
using DotNETInternshipTasksApp.Task01_Palindrome;
using DotNETInternshipTasksApp.Task02_CoinSplitter;
using DotNETInternshipTasksApp.Task03_MissingNumber;
using DotNETInternshipTasksApp.Task04_BracketChecker;
using DotNETInternshipTasksApp.Task05_StairVariants;
using DotNETInternshipTasksApp.Task07_EntityFramework;
using DotNETInternshipTasksApp.Task07_EntityFramework.Models;
using DotNETInternshipTasksApp.Task08_CountryDataGenerator;
using DotNETInternshipTasksApp.Task09_Synchronization;

namespace DotNETInternshipTasksApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ✅ Удаляем базу ДО создания контекста
            if (File.Exists("school.db"))
                File.Delete("school.db");

            // Task 1 — Palindrome Checker
            Console.WriteLine("Task 1 — Palindrome Checker:");
            string testWord = "Level";
            bool result = PalindromeChecker.sPalindrome(testWord);
            Console.WriteLine($"Is the word '{testWord}' a palindrome? {result}");
            Console.WriteLine();

            // Task 2 — MinSplit
            Console.WriteLine("Task 2 — MinSplit:");
            int amount = 93;
            int minCoins = CoinSplitter.MinSplit(amount);
            Console.WriteLine($"The amount {amount} tetri can be changed with a minimum of {minCoins} coins.");
            Console.WriteLine();

            // Task 3 — NotContains
            Console.WriteLine("Task 3 — NotContains:");
            int[] testArray = { 1, 2, 3, 5 };
            int missing = MissingNumberFinder.NotContains(testArray);
            Console.WriteLine($"The smallest positive number not present in the array is: {missing}");
            Console.WriteLine();

            // Task 4 — IsProperly
            Console.WriteLine("Task 4 — IsProperly:");
            string sequence = "(()())";
            bool isValid = BracketChecker.IsProperly(sequence);
            Console.WriteLine($"Is the bracket sequence \"{sequence}\" valid? {isValid}");
            Console.WriteLine();

            // Task 5 — CountVariants
            Console.WriteLine("Task 5 — CountVariants:");
            int stairs = 5;
            int variants = StairCounter.CountVariants(stairs);
            Console.WriteLine($"Number of ways to climb {stairs} steps: {variants}");
            Console.WriteLine();

            // Task 7 — Entity Framework GetAllTeachersByStudent
            Console.WriteLine("Task 7 — EF GetAllTeachersByStudent(\"გიორგი\"):");

            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            var service = new TeacherService(context);
            service.SeedData();

            var teachers = service.GetAllTeachersByStudent("გიორგი");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"{teacher.FirstName} {teacher.LastName} — {teacher.Subject}");
            }
            Console.WriteLine();

            // Task 8 — Generate Country Files
            Console.WriteLine("Task 8 — Generate Country Files:");
            var countryService = new CountryService();
            bool filesCreated = await countryService.GenerateCountryDataFiles();

            if (filesCreated)
            {
                Console.WriteLine("✅ Country data files generated.");
            }
            else
            {
                Console.WriteLine("⚠️ No files were generated.");
            }

            Console.WriteLine();


            // Task 9 — Console Synchronization
            Console.WriteLine("Task 9 — Console Synchronization with SemaphoreSlim:");
            Console.WriteLine("Press ESC to stop the loop...\n");
            var printer = new ConsolePrinter();
            await printer.StartAsync();
        }
    }
}
