using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Danie> dania = new List<Danie>{
                new DanieGlowne("schabowy",15.00),
                new Zupa("ogórkowa", 10.00),
                new Zupa("pomidor", 13.00),
                new DanieGlowne("gołąbki", 10.00),
                new Zupa("rosół", 5.00)
            };

            dania.Sort();

            foreach (var item in dania)
            {
                item.Info();
            }

            Console.ReadKey();
        }
    }

    public abstract class Danie : IComparable
    {
        protected string nazwa;
        protected double cena;

        public Danie() { }
        public Danie(string nazwa, double cena)
        {
            this.cena = cena;
            this.nazwa = nazwa;
        }

        public virtual void Info()
        {
            Console.WriteLine("Danie, nazwa: {0}, cena: {1}", cena, nazwa);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Danie otherDanie = obj as Danie;
            if (otherDanie != null)
                return this.cena.CompareTo(otherDanie.cena);
            else
                throw new ArgumentException("Object is not a Danie");
        }
    }

    public class Zupa : Danie
    {
        public Zupa(string nazwa, double cena)
        {
            this.cena = cena;
            this.nazwa = nazwa;
        }

        public override void Info()
        {
            Console.WriteLine("Zupa:");
            base.Info();
        }
    }

    public class DanieGlowne : Danie
    {
        public DanieGlowne(string nazwa, double cena)
        {
            this.cena = cena;
            this.nazwa = nazwa;
        }

        public override void Info()
        {
            Console.WriteLine("Danie Główne:");
            base.Info();
        }
    }
}
