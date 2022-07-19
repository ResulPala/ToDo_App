using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class Board
    {
        public static List<Card> Line = new List<Card>();

        public Board()
        {
            Line.Add(new Card("Rutin","Erdal'i uyandirma",1,1,"TODO"));
            Line.Add(new Card("Is","Asit Anhidrit al",2,1, "IN PROGRESS"));
            Line.Add(new Card("Is","Halo'nun 10 kagidini al ",4,1, "TODO"));
            Line.Add(new Card("Is","Urun tattirma",1,4, "DONE"));
        }
        
    }
}