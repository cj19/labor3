using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor3
{

    public delegate void HelyzetjelentesEH(int uzemanyagSzint);
    class Auto
    {
        public int Uzemanyag { get; set; }

        private HelyzetjelentesEH helyzet;

        public void FeliratkozasHelyzetre(HelyzetjelentesEH metodus)
        {
            helyzet += metodus;
        }

        public void LeiratkozasHelyzetrol(HelyzetjelentesEH metodus)
        {
            helyzet -= metodus;
        }

        public void Verseny()
        {
            if (Uzemanyag > 0)
            {
                this.Uzemanyag -= 10;

                //Visszajelzés eseményként
                helyzet(this.Uzemanyag);
            }
        }

    }

    public class Ertesito
    {
        public void HelyzetJelentes(int uzemanyag)
        {
            Console.WriteLine("Maradék üzemanyag: " + uzemanyag);
        }
    }
    class esemenykezeles_delegate
    {
        static void Ertesito(int uzemanyag)
        {
            Console.WriteLine("Maradék üzemanyag: " + uzemanyag);
        }

        static void Main(string[] args)
        {
            Auto auto = new Auto() { Uzemanyag = 40 };
            Ertesito ertesito = new Ertesito();
            // auto.helyzet += Ertesito;
            //auto.helyzet += ertesito.HelyzetJelentes;

            auto.FeliratkozasHelyzetre(ertesito.HelyzetJelentes);

            auto.Verseny();

            //auto.helyzet = 100;

            Console.ReadLine();


        }
    }
}
