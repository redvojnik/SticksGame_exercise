using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SticksGame
{
    public delegate void GameHandler(string message);
    class SticksGame
    {
        public SticksGameStatus gameStatus = SticksGameStatus.IsStarted;
        private int AmountSticks = 10;
        GameHandler taken;
        public void RegistGameHandler(GameHandler currentDelegate) => this.taken = currentDelegate;
        public SticksGame(int AmountSticks) => this.AmountSticks = AmountSticks;
        public void ComputerTake()
        {
                Random random = new();
                int amountSticks = random.Next(1, this.AmountSticks < 3
                                                  ? this.AmountSticks
                                                  : 3);
                this.AmountSticks -= amountSticks;
                taken?.Invoke($"Computer made its move. It took <<{amountSticks}>> sticks.\n" +
                              $"There are << {this.AmountSticks} >> sticks left.\n");
        }
        public void Take(int amountSticks)
        {
                AmountSticks -= amountSticks;
                taken?.Invoke($"You took << {amountSticks} >> sticks.\n" +
                              $"There are << {AmountSticks} >> sticks left!\n");
        }
        public int InputAmountSticks()
        {
            int value = int.Parse(Console.ReadLine());
            if (value > 0 && value < 4 && value <= AmountSticks)
                return value;
            else
            {
                Console.Write("\n\nYou put incorrect number. Try again!\n" +
                                  "Your number is ");
                return InputAmountSticks();
            }
        }
        public void CheckGameStatus()
        {
            if (AmountSticks == 0)
            {
                gameStatus = SticksGameStatus.IsEnded;
                Console.WriteLine("The game is ended.");
            }
        }
    }
}
