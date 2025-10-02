using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNETInternshipTasksApp.Task09_Synchronization
{
    public class ConsolePrinter
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private bool _isRunning = true;

        public async Task StartAsync()
        {
            // 3 задачи одновременно:
            var printerTask = PrintZeroOneLoopAsync();
            var messageTask = ShowMessagePeriodicallyAsync();
            var exitListenerTask = ListenForExitAsync();

            await Task.WhenAny(printerTask, messageTask, exitListenerTask);

            // После выхода — останавливаем всё
            _isRunning = false;
            Console.WriteLine("\n\n🛑 The program is complete. Press any key....");
        }

        private async Task PrintZeroOneLoopAsync()
        {
            int counter = 0;
            while (_isRunning)
            {
                await _semaphore.WaitAsync();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(counter % 2);
                Console.ResetColor();

                _semaphore.Release();

                counter++;
                await Task.Delay(100); 
            }
        }

        private async Task ShowMessagePeriodicallyAsync()
        {
            while (_isRunning)
            {
                await Task.Delay(5000);

                await _semaphore.WaitAsync();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNeo, you are the chosen one\n");
                Console.ResetColor();

                _semaphore.Release();

                await Task.Delay(5000);
            }
        }

        private async Task ListenForExitAsync()
        {
            await Task.Run(() =>
            {
                while (_isRunning)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Escape)
                        {
                            _isRunning = false;
                            break;
                        }
                    }
                    Thread.Sleep(100); // опрос раз в 100 мс
                }
            });
        }
    }
}
