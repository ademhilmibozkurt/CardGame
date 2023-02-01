using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class DistributeCards
    {
        Random rndMaker = new Random();    

        string[] cards = new string[18] { "S1","S2","S3","S4","S5","M1","M2","M3","M4","M5","K1","K2","K3","K4","K5","RD","RD","RD"};
        string[] playerMine = new string[6] { "","","","","",""};
        string[] botMine1   = new string[6] { "","","","","",""};
        string[] botMine2   = new string[6] { "","","","","",""};
        int a = 0 , b = 0 , c = 0;

        public void Distribute()
        {
            for (int i = 0; i <= 5; i++)
            {
                a = rndMaker.Next(0, 18);
                if (cards[a] == "")
                {
                    i--;
                }
                else
                {
                    playerMine[i] = cards[a];
                    cards[a] = "";
                }
            }

            for (int i = 0; i <= 5; i++)
            {
                b = rndMaker.Next(0, 18);
                if (cards[b] == "")
                {
                    i--;
                }
                else
                {
                    botMine1[i] = cards[b];
                    cards[b] = "";
                }
            }

            for (int i = 0; i <= 5; i++)
            {
                c = rndMaker.Next(0, 18);
                if (cards[c] == "")
                {
                    i--;
                }
                else
                {
                    botMine2[i] = cards[c];
                    cards[c] = "";
                }
            }
        }

        public void PrintMine()
        {
            Console.WriteLine($"Kartlarınız : 1.{playerMine[0]} ,2.{playerMine[1]} ,3.{playerMine[2]} ,4.{playerMine[3]} ,5.{playerMine[4]} ,6.{playerMine[5]},7.PAS");
            Console.WriteLine($"PC1 Kartları: {botMine1[0]} , {botMine1[1]} , {botMine1[2]} , {botMine1[3]} , {botMine1[4]} , {botMine1[5]}");
            Console.WriteLine($"PC2 Kartları: {botMine2[0]} , {botMine2[1]} , {botMine2[2]} , {botMine2[3]} , {botMine2[4]} , {botMine2[5]} \n\n");
        }

        public string[] PMineReturner()
        {
            return playerMine;
        }

        public string[] BotMine1Returner()
        {
            return botMine1;
        }

        public string[] BotMine2Returner()
        {
                return botMine2;
        }
    }
}
