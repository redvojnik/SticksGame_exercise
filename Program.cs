using System;

namespace SticksGame
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input desired amount of sticks to play. Default value is << 10 >>.\n" +
                              "You must input date from << 10 >> to << 100 >> Your date is ");
            int desiredValueOfSticks = PrintDesiredAmountSticks();
            var sticksGame = new SticksGame(desiredValueOfSticks);
            sticksGame.RegistGameHandler(PrintMessage);
            //создаем цикл для игры в палочки. После каждого
            while (sticksGame.gameStatus == SticksGameStatus.IsStarted)
            {
                Console.WriteLine("\n\nPlease input number of sticks from 1 to 3. Your number is ");
                int userSticksNumber = sticksGame.InputAmountSticks();
                sticksGame.Take(userSticksNumber);
                sticksGame.RegistGameHandler(PrintMessage);
                sticksGame.CheckGameStatus();
                sticksGame.ComputerTake();
                sticksGame.RegistGameHandler(PrintMessage);
                sticksGame.CheckGameStatus();
            }
            Console.Read();

           static void PrintMessage (string message) => Console.WriteLine(message);
            // метод для общего количества палочек, от уменьшения которого будет идти игра. Проивзодим проверку на корректность ввода числа
           static int PrintDesiredAmountSticks ()
           {
                int value = int.Parse(Console.ReadLine());
                if (value >= 10 && value <= 100)
                    return value;
                else
                {
                    Console.Write("\nYou put incorrect number. Try again!\n" +
                                      "Your date is ");
                    return PrintDesiredAmountSticks();
                }
           }        
        }
    }
}
