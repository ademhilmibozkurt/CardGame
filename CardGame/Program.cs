using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame game = new PlayGame();
            game.Play();

            Console.ReadKey();
        }
    }
}
