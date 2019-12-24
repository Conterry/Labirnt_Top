using System;

namespace Labirint_Translate
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
            while(IsEndGame()==false){
                get_input();
                logyc();
                Draw();
            }
            Console.WriteLine("YOU WON");
        }
        static int width = 10, length = 12;
        static char[,] field;
        static int freq = 28;
        static int dx = 0, dy = 0;
        static int charX = 0, charY = 0;
        static int finishX = 0, finishY = 0;

        static void Draw()
        {
            for (int i=0; i < length; i++)
            {
                for(int j=0; j<width; j++)
                {
                    if(charX == j && charY == i)
                    {
                        Console.Write('@');
                    }
                    else
                    {
                        Console.Write(field[i,j]);
                    }
                }
                Console.WriteLine();
            }
            

        }

        static void Init()
        {

            field = new char[length, width];
            int rand_value;
            char symbol;
            for(int i=0; i<length; i++)
            {
                for(int j=0; j<width; j++)
                {
                    Random rand = new Random();
                    rand_value = rand.Next(0, 100);
                    if (rand_value < freq)
                    {
                        symbol = '#';
                    }
                    else
                    {
                        symbol = ' ';
                    }
                    field[i,j] = symbol;
                }
            }
            Random rand1 = new Random();
            charX = rand1.Next(0, width - 1);
            charY = rand1.Next(0, length - 1);
            finishX = rand1.Next(0, width - 1);
            finishY = rand1.Next(0, length - 1);
            field[finishX, finishY] = 'F';
        }


        static bool IsEndGame()
        {
            return charX == finishX && charY == finishY;
        }
        static void get_input()
        {
            char inp = Console.ReadKey().KeyChar;
            Console.WriteLine();
            dx = 0; dy = 0;
            
            if(inp=='S' || inp == 's'){
                dy = 1;
            }
            if(inp=='W' || inp == 'w')
            {
                dy = -1;
            }
            if(inp=='A' || inp == 'a')
            {
                dx = -1;
            }
            if(inp=='D' || inp == 'd')
            {
                dx = 1;
            }
            //if(inp=='B' || inp== 'b')
            //{
              //  Bomb();
            //}
        }
        static bool CanGoTo(int newX, int newY)
        {
            if(newX<0 || newY<0 || newX>=width || newY >= length)
            {
                return false;
            }
            else if (field[newY, newX] == '#')
            {
                return false;
            }
            else
            {
                return true;
            }   
        }

        static void Bomb()
        {
            field[charX + 1, charY] = ' ';
            field[charX, charY + 1] = ' ';
            field[charX + 1, charY + 1] = ' ';
            field[charX - 1, charY - 1] = ' ';
            field[charX - 1, charY] = ' ';
            field[charX, charY - 1] = ' ';
            field[charX + 1, charY - 1] = ' ';
            field[charX - 1, charY + 1] = ' ';
        }

        static void GoTo(int newX, int newY)
        {
            charX = newX;
            charY = newY;
        }

        static void TryGoTo(int newX,int newY)
        {
            if(CanGoTo(newX, newY))
            {
                GoTo(newX, newY);
            }
        }

        static void logyc()
        {
            TryGoTo(charX + dx, charY + dy);
        }
    }

}
