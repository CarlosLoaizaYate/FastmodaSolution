using Fastmoda.Application.IService;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fastmoda.Application.Service
{
    public class LetterSoupService : ILetterSoupService
    {
        public bool contieneNombre(string[] info, string nombre)
        {
            char[,] Soup = new char[info.Length, info[0].Length];

            for (int arrayString = 0; arrayString < info.Length; arrayString++)
            {
                for (int arraychar = 0; arraychar < info[arrayString].Length; arraychar++)
                {
                    Soup[arrayString, arraychar] = info[arrayString].ToUpper().ToCharArray()[arraychar];
                }
            }

            int x = Soup.GetLength(0);
            int y = Soup.GetLength(1);

            string[] vertical = new string[y];
            string[] horizantal = new string[x];
            string[] diagonal1 = new string[(x * 2) - 1];
            string[] diagonal2 = new string[(x * 2) - 1];


            for (int PositionX = 0; PositionX < x; PositionX++)
            {
                for (int PositionY = 0; PositionY < y; PositionY++)
                {
                    horizantal[PositionX] += Soup[PositionX, PositionY].ToString();
                }
            }

            for (int PositionY = 0; PositionY < y; PositionY++)
            {
                for (int PositionX = 0; PositionX < x; PositionX++)
                {
                    vertical[PositionY] += Soup[PositionX, PositionY].ToString();
                }
            }

            int Position = 0;

            for (int PositionX = x - 1; 0 <= PositionX; PositionX--)
            {
                int dif = PositionX - (x - 1);

                var newPositionX = PositionX;
                for (int PositionY = 0; PositionY <= dif * -1; PositionY++)
                {
                    diagonal1[Position] += Soup[newPositionX, PositionY].ToString();
                    newPositionX++;
                }
                Position++;
            }

            var newPositionY = 1;
            for (int PositionX = 0; PositionX < x; PositionX++)
            {
                var newPositionX = 0;
                for (int PositionY = newPositionY; PositionY < y; PositionY++)
                {
                    diagonal1[Position] += Soup[newPositionX, PositionY].ToString();
                    newPositionX++;
                }
                newPositionY++;
                Position++;
            }

            Position = 0;
            for (int PositionX = 0; PositionX < x; PositionX++)
            {
                int dif = x - PositionX;

                var newPositionX = PositionX;
                for (int PositionY = 0; PositionY <= PositionX; PositionY++)
                {
                    diagonal2[Position] += Soup[newPositionX, PositionY].ToString();
                    newPositionX--;
                }
                Position++;
            }

            var newPositionXdiagonal = x - 1;

            for (int PositionY = 1; PositionY < x; PositionY++)
            {
                newPositionY = PositionY;
                for (int PositionX = newPositionXdiagonal; 0 < PositionX; PositionX--)
                {
                    diagonal2[Position] += Soup[PositionX, newPositionY].ToString();
                    newPositionY++;
                    if (newPositionY == 6)
                        break;
                }
                Position++;
            }

            nombre = nombre.ToUpper();
            if ((vertical.FirstOrDefault(x => x.Contains(nombre)) != null) || (horizantal.FirstOrDefault(x => x.Contains(nombre)) != null) || (diagonal1.FirstOrDefault(x => x.Contains(nombre)) != null) || (diagonal2.FirstOrDefault(x => x.Contains(nombre)) != null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
