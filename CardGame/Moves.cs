using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Moves
    {
        Random rndMaker = new Random();
        public int PlayerMoveF(string[] playerMine, string lighted)
        {
            int choiseNum = 0;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Kart Numarası Seçin! => ");
                choiseNum = Convert.ToInt32(Console.ReadLine()) - 1;
                if ((choiseNum >= 0 || choiseNum < 7) && playerMine[choiseNum] != "RD")
                {
                    return choiseNum;
                }
                else if (playerMine[choiseNum] == "RD" || playerMine[choiseNum] == "PAS")
                {
                    Console.WriteLine("Oyuna Özel Kartla Başlanamaz !");
                    i--;
                }
                else
                {
                    Console.WriteLine("Hatalı Giriş !");
                    i--;
                }
            }
            return 0;
        }
        public int PlayerMove(string[] playerMine, string lighted)
        {
            int choiseNum = 0;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Kart Numarası Seçin! => ");
                choiseNum = Convert.ToInt32(Console.ReadLine()) - 1;
                
                if (choiseNum == 6)
                {
                    return choiseNum;
                }
                else if ((choiseNum >= 0 || choiseNum < 6) && playerMine[choiseNum] != "used" && (lighted[0] == playerMine[choiseNum][0] || lighted[1] == playerMine[choiseNum][1]))
                {
                    lighted = playerMine[choiseNum];
                    Console.WriteLine($" {lighted} Kartını Seçtiniz !");
                    Console.WriteLine($" KART  :  {lighted}");
                    return choiseNum;
                }
                else if (playerMine[choiseNum] == "used")
                {
                    Console.WriteLine("Bu kart Kullanılmış !");
                    i--;
                }
                else if(playerMine[choiseNum] == "RD")
                {
                    return choiseNum;      
                }
                else
                {
                    Console.WriteLine("Hatalı Giriş !");
                    i--;
                }
            }
            return 0;
        }
        public int Move1(string[] botMine1, string lighted)
        {
            int choiseNum = 0; int p = 0;
            for (int i = 0; i < 1; i++)
            {
                choiseNum = rndMaker.Next(6);
                if (p == 6)
                {
                    return 6;
                }
                else
                {
                    if (botMine1[choiseNum] == "used")
                    {
                        i--; p++;
                    }
                    else if (botMine1[choiseNum] == "RD")
                    {
                        for (int t = 0; t <= 5; t++)
                        {
                            if (lighted[0] == botMine1[t][0] || lighted[1] == botMine1[t][1])
                            {
                                choiseNum = t;
                            }
                        }
                        return choiseNum;
                    }
                    else if (lighted[0] == botMine1[choiseNum][0] || lighted[1] == botMine1[choiseNum][1])
                    {
                        return choiseNum;
                    }
                    else { p++;i--; }
                }
            } return 7;
        }
        public int Move2(string[] botMine2, string lighted)
        {
            int choiseNum = 0; int p = 0;
            for (int i = 0; i < 1; i++)
            {
                choiseNum = rndMaker.Next(6);
                if (p == 6)
                {
                    return 6;
                }
                else
                {
                    if (botMine2[choiseNum] == "used")
                    {
                        i--; p++;
                    }
                    else if (botMine2[choiseNum] == "RD")
                    {
                        for (int t = 0; t <= 5; t++)
                        {
                            if (lighted[0] == botMine2[t][0] || lighted[1] == botMine2[t][1])
                            {
                                choiseNum = t;
                            }
                        }
                        return choiseNum;
                    }
                    else if (lighted[0] == botMine2[choiseNum][0] || lighted[1] == botMine2[choiseNum][1])
                    {
                        return choiseNum;
                    }
                    else { p++;i--; }
                }
            }
            return 7;
        }
        public bool IsRunOut(string[] mine)
        {
            int holder = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (mine[i] == "used")
                {
                    holder++;
                }
            }
            if (holder == 6)
            {
                return true;
            }
            return false;
        }
    }
}
