using System;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board=new Board();
            PersonsData personInfo = new PersonsData();
            
            Start.StartUI();
        }
    }
}