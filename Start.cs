using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class Start
    {
        public static void StartUI()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Liste");
            Console.WriteLine("(2) Board'a Kart Ekle");
            Console.WriteLine("(3) Board'dan Kart Sil");
            Console.WriteLine("(4) Kart Taşı");

            int selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    SelectionOperations.ListBoard();
                    break;
                case 2:
                    SelectionOperations.AddBoard();
                    break;
                case 3:
                    SelectionOperations.RemoveBoard();
                    break;
                case 4:
                    SelectionOperations.TransBoard();
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız.");
                    Start.StartUI();
                    break;


            }


        }
        
    }
}