using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class PlayGame
    {
        DistributeCards returner = new DistributeCards();
        Moves move = new Moves();
        public void Play()
        {
            string[] lighted = new string[2] { "A","0"};
            returner.Distribute();
            returner.PrintMine();
            string[] playerMine = returner.PMineReturner();
            string[] botMine1 = returner.BotMine1Returner();
            string[] botMine2 = returner.BotMine2Returner();
            char[] color = new char[3]{ 'S', 'M', 'K' }; int pHolder = 0;
            int choiseNum = 0, num1 = 0, num2 = 0, num1h = 1, num2h = 1;
            string choise; string pas = "";

            for (int i = 0; i <= 5; i++)
            {
                if (i == 0)
                {
                    choiseNum = move.PlayerMoveF(playerMine, lighted[0]+lighted[1]);
                    lighted[0] = playerMine[choiseNum][0].ToString();
                    lighted[1] = playerMine[choiseNum][1].ToString();
                    Console.WriteLine($" {lighted[0]+lighted[1]} Kartını Seçtiniz !");
                    Console.WriteLine($" KART  :  {lighted[0] + lighted[1]}\n");

                    num1 = move.Move1(botMine1, lighted[0] + lighted[1]);
                    if (num1 == 6)
                    {
                        pas = "PAS";
                        Console.WriteLine("PC1 PAS Dedi !");
                        Console.WriteLine($"KART  :  {lighted[0] + lighted[1]}\n");
                    }
                    else if (botMine1[num1] == "RD" && pas == "")
                    {
                        if (num1h == 1 && color[0].ToString() != lighted[0])
                        {
                            lighted[0] = color[0].ToString(); num1h++;
                        }
                        else if (num1h == 2 && color[1].ToString() != lighted[0])
                        {
                            lighted[0] = color[1].ToString(); num1h++;
                        }
                        else
                        {
                            lighted[0] = color[2].ToString();
                        }
                        Console.WriteLine($"PC1 RD kullandı KART : {lighted[0] + lighted[1]}\n"); botMine1[num1] = "used";
                    }
                    else
                    {
                        lighted[0] = botMine1[num1][0].ToString();
                        lighted[1] = botMine1[num1][1].ToString();
                        Console.WriteLine($"PC1 {lighted[0] + lighted[1]} Kartını Seçti !");
                        Console.WriteLine($" KART  :  {lighted[0] + lighted[1]}\n"); botMine1[num1] = "used";
                    }

                    if (pas == "PAS")
                    {
                        pas = "";
                        pHolder++;
                    }else { pHolder = 0; }
                    num2 = move.Move2(botMine2, lighted[0]+lighted[1]);
                    if( num2 == 6)
                    {
                        pas = "PAS";
                        Console.WriteLine("PC2 PAS Dedi !");
                        Console.WriteLine($"KART  :  {lighted[0] + lighted[1]}\n");
                    }
                    else if (botMine2[num2] == "RD")
                    {
                        if (num2h == 1 && color[0].ToString() != lighted[0])
                        {
                            lighted[0] = color[0].ToString();num2h++;
                        }
                        else if (num2h == 2 && color[1].ToString() != lighted[0])
                        {
                            lighted[0] = color[1].ToString();num2h++;
                        }
                        else
                        {
                            lighted[0] = color[2].ToString();
                        }
                        Console.WriteLine($"PC2 RD kullandı KART : {lighted[0] + lighted[1]}\n"); botMine2[num2] = "used";
                    }
                    else
                    {
                        lighted[0] = botMine2[num2][0].ToString();
                        lighted[1] = botMine2[num2][1].ToString();
                        Console.WriteLine($"PC2 {lighted[0] + lighted[1]} Kartını Seçti !");
                        Console.WriteLine($" KART  :  {lighted[0] + lighted[1]}"); botMine2[num2] = "used";
                    }
                    playerMine[choiseNum] = "used";
                }
                else
                {
                    Console.WriteLine($"\nKartlarınız : 1.{playerMine[0]} ,2.{playerMine[1]} ,3.{playerMine[2]} ,4.{playerMine[3]} ,5.{playerMine[4]} ,6.{playerMine[5]},7.PAS");
                    if (pas == "PAS")
                    {
                        pHolder++;
                    }else{ pHolder = 0; }
                    choiseNum = move.PlayerMove(playerMine, lighted[0]+lighted[1]);
                    if (choiseNum == 6)
                    {
                        pas = "PAS";
                        Console.WriteLine("PAS Dediniz !");
                        Console.WriteLine($"KART  :  {lighted[0] + lighted[1]}\n");
                    }
                    else if (playerMine[choiseNum] == "RD")
                    {
                        for (int t = 0; t < 1; t++)
                        {
                            Console.WriteLine("RD Kartını Seçtiniz ! \nRenk Girin !");
                            choise = Console.ReadLine().Trim().ToUpper();
                            if ((choise == "K" && lighted[0] != "K") || (choise == "S" && lighted[0] != "S") || (choise == "M" && lighted[0] != "M"))
                            {
                                lighted[0] = choise;
                                Console.WriteLine($" {lighted[0] + lighted[1]} Kartını Seçtiniz !");
                                Console.WriteLine($" KART  :  {lighted[0] + lighted[1]}\n");
                            }
                            else
                            {
                                Console.WriteLine("Hatalı Giriş !\n");
                                t--;
                            }
                        }
                    }
                    else
                    {
                        lighted[0] = playerMine[choiseNum][0].ToString();
                        lighted[1] = playerMine[choiseNum][1].ToString();
                    }
                    if (choiseNum != 6)
                    {
                        playerMine[choiseNum] = "used";
                    }
                    if (move.IsRunOut(playerMine) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOyunu Siz Kazandınız!");
                        Console.WriteLine("Oyun Kapanıyor 2s...");
                        System.Threading.Thread.Sleep(2000);
                        Environment.Exit(1);
                    }

                    if (pas == "PAS")
                    {
                        pas = "";
                        pHolder++;
                    }
                    else { pHolder = 0; }
                    num1 = move.Move1(botMine1, lighted[0]+lighted[1]);
                    if(num1  == 6)
                    {
                        pas = "PAS";
                        Console.WriteLine("\nPC1 PAS Dedi !");
                        Console.WriteLine($"KART  :  {lighted[0] + lighted[1]}\n");
                    }
                    else if (botMine1[num1] == "RD" && pas == "")
                    {
                        if (num1h == 1 && color[0].ToString() != lighted[0])
                        {
                            lighted[0] = color[0].ToString();num1h++;
                        }
                        else if (num1h == 2 && color[1].ToString() != lighted[0])
                        {
                            lighted[0] = color[1].ToString();num1h++;
                        }
                        else
                        {
                            lighted[0] = color[2].ToString();
                        }
                        Console.WriteLine($"\nPC1 RD kullandı KART : {lighted[0] + lighted[1]}\n"); botMine1[num1] = "used";
                    }
                    else
                    {
                        lighted[0] = botMine1[num1][0].ToString();
                        lighted[1] = botMine1[num1][1].ToString();
                        Console.WriteLine($"\nPC1 {lighted[0] + lighted[1]} Kartını Seçti !");
                        Console.WriteLine($" KART  :  {lighted[0] + lighted[1]}\n"); botMine1[num1] = "used";
                    }
                    if (move.IsRunOut(botMine1) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOyunu PC1 Kazandı!");
                        Console.WriteLine("Oyun Kapanıyor 2s...");
                        System.Threading.Thread.Sleep(2000);
                        Environment.Exit(1);
                    }
                    
                    if (pas == "PAS")
                    {
                        pas = "";
                        pHolder++;
                    }
                    else { pHolder = 0; }
                    num2 = move.Move2(botMine2, lighted[0]+lighted[1]);
                    if (num2 == 6)
                    {
                        pas = "PAS";
                        Console.WriteLine("PC2 PAS Dedi !");
                        Console.WriteLine($"KART  :  {lighted[0] + lighted[1]}");
                    }
                    else if (botMine2[num2] == "RD" && pas == "")
                    {
                        if (num2h == 1 && color[0].ToString() != lighted[0])
                        {
                            lighted[0] = color[0].ToString();num2h++;
                        }
                        else if (num2h == 2 && color[1].ToString() != lighted[0])
                        {
                            lighted[0] = color[1].ToString();num2h++;
                        }
                        else 
                        {
                            lighted[0] = color[2].ToString();
                        }
                        Console.WriteLine($"PC2 RD kullandı KART : {lighted[0] + lighted[1]} \n"); botMine2[num2] = "used";
                    }
                    else
                    {
                        lighted[0] = botMine2[num2][0].ToString();
                        lighted[1] = botMine2[num2][1].ToString();
                        Console.WriteLine($"PC2 {lighted[0] + lighted[1]} Kartını Seçti !");
                        Console.WriteLine($" KART  :  {lighted[0] + lighted[1]}\n"); botMine2[num2] = "used";
                    }
                    if (pas == "PAS")
                    {
                        pas = "";
                        pHolder++;
                    }
                    else { pHolder = 0; }
                    if (move.IsRunOut(botMine2) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOyunu PC2 Kazandı!");
                        Console.WriteLine("Oyun Kapanıyor 2s...");
                        System.Threading.Thread.Sleep(2000);
                        Environment.Exit(1);
                    }
                    if (pHolder >= 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nOyun Berabere Bitti !!");
                        Console.WriteLine("Oyun Kapanıyor 3s...");
                        System.Threading.Thread.Sleep(3000);
                        Environment.Exit(1);
                    }
                }
            }
        }
    }
}

