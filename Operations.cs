using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class SelectionOperations
    {
        public static void ListBoard() 
        {
            Console.WriteLine("\nTODO Line");
            Console.WriteLine("**********************");
            ListAll(Board.Line,"TODO");

            Console.WriteLine("\nIN PROGRESS Line");
            Console.WriteLine("**********************");
            ListAll(Board.Line, "IN PROGRESS");

            Console.WriteLine("\nDONE Line");
            Console.WriteLine("**********************");
            ListAll(Board.Line,"DONE");

            Start.StartUI();


        }

        public static void ListAll(List<Card> cards,string lines)
        {
            foreach (var item in cards)
            {
                if (lines==item.Line)
                {
                    Console.WriteLine("\nBaşlık: " + item.Title);
                    Console.WriteLine("İçerik: " + item.Content);
                    Console.WriteLine("Atanan Kişi: " + PersonsData.person.Find(a => a.PersonId == item.PersonID).Name);
                    Console.WriteLine("Büyüklük: " + ((DefaultSize)item.Size).ToString());
                    Console.WriteLine("-");
                }
                
            }
        }


        public static void AddBoard()
        {
            Console.Write("\nBaşlık Giriniz\t: ");
            string titleAdd = Console.ReadLine();
            Console.Write("İçerik Giriniz\t: ");
            string contentAdd = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz => XS(1),S(2),M(3),L(4),XL(5) :");
            int sizeAdd = int.Parse(Console.ReadLine());
            Console.Write("Kişi Seçiniz\t: ");
            int personidAdd = int.Parse(Console.ReadLine());

            if (PersonsData.person.Find(a=>a.PersonId==personidAdd).PersonId==personidAdd) 
            {
                Board.Line.Add(new Card(titleAdd, contentAdd, personidAdd, sizeAdd, "TODO")); 
            }
            else
            {
                Console.WriteLine("Hatalı giriş yaptınız!");
            }

            Start.StartUI();
        }


        public static void RemoveBoard()
        {
            Console.WriteLine("\nLütfen silmek istediğiniz kartı seçiniz.");
            Console.Write("Lütfen kart başlığını yazınız:  ");
            string titleBoard= (Console.ReadLine()).ToLower();
            var removeBoard = Board.Line.Where(x => x.Title.ToLower() == titleBoard).ToList(); 
            if (removeBoard.Count>0)
            {
                for (int i = 0; i < removeBoard.Count; i++) 
                {
                    Board.Line.RemoveAll(x => x.Title.ToLower() == titleBoard);
                }
                Console.WriteLine("Silme işlemi gerçekleştirildi.");
                Start.StartUI();
            }

            else
            {
                NotFoundBoard();
            }
        }

        public static void TransBoard() 
        {
            Console.WriteLine(" \nLütfen taşımak istediğiniz kartı seçiniz");
            Console.Write("Lütfen kart başlığını yazınız:  ");
            string titleBoard = (Console.ReadLine()).ToLower();
            var linqPerson = Board.Line.Where(x => x.Title.ToLower() == titleBoard).ToList();
            if (linqPerson.Count >0)
            {
                TransBoardList(titleBoard);

                Console.WriteLine("Lütfen taşımak istediğiniz bölümü seçiniz: ");
                Console.WriteLine(" (1) TODO");
                Console.WriteLine(" (2) IN PROGRESS");
                Console.WriteLine(" (3) DONE");
                int selection = int.Parse(Console.ReadLine());
                if (selection == 1)
                {
                    linqPerson[0].Line = "TODO";
                    TransBoardList(titleBoard);
                }

                else if (selection == 2)
                {
                    linqPerson[0].Line = "IN PROGRESS";
                    TransBoardList(titleBoard);
                }
                    
                else if (selection == 3)
                {
                    linqPerson[0].Line = "DONE";
                    TransBoardList(titleBoard);
                }
                else
                    Console.WriteLine("Hatalı bir seçim yaptınız!");
                Start.StartUI();
            }
            else
            {
                NotFoundBoard();
            }
        }

        public static void TransBoardList(string titleBoard)
        {
            var linqPerson = Board.Line.Where(x => x.Title.ToLower() == titleBoard).ToList();
            Console.WriteLine("\nKart Bilgileri:");
            Console.WriteLine(" **************************************");
            Console.WriteLine("Başlık: " + linqPerson[0].Title);
            Console.WriteLine("İçerik: " + linqPerson[0].Content);
            Console.WriteLine("Atanan Kişi: " + PersonsData.person.Find(a => a.PersonId == linqPerson[0].PersonID).Name);
            Console.WriteLine("Büyüklük: " + ((DefaultSize)linqPerson[0].Size).ToString());
            Console.WriteLine("Line: " + linqPerson[0].Line);
        }


        public static void NotFoundBoard([CallerMemberName] string callermemberName = "")
        {
            Console.WriteLine("\nAradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine(" * İşlemi sonlandırmak için : (1).");
            Console.WriteLine(" * Yeniden denemek için : (2)");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
                Start.StartUI();
            else if (select == 2)
            {
                if (callermemberName == "RemoveBoard")
                {
                    RemoveBoard();
                }
                else if (callermemberName == "TransBoard")
                {
                    TransBoard();
                }
            }
            else { Console.WriteLine("Yanlış seçim yaptınız."); Start.StartUI(); }
        }
    }
}