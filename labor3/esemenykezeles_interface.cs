using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor3
{

    public interface IUzemanyagHelyzet
    {
        void UzemanyagVisszajelzo(int mennyiseg);
    }

    class Auto
    {
        private IUzemanyagHelyzet uzemenyanyagHelyzet;
        public int Uzemanyag { get; set; }

        public Auto(int uzi, IUzemanyagHelyzet uh)
        {
            this.Uzemanyag = uzi;
            this.uzemenyanyagHelyzet = uh;
        }

        public void Verseny()
        {
            if(Uzemanyag>0)
            {
                Uzemanyag -= 10;

                //Visszajelzes
                uzemenyanyagHelyzet.UzemanyagVisszajelzo(this.Uzemanyag);
            }
        }
    }

    class Jelzo : IUzemanyagHelyzet
    {
        public void UzemanyagVisszajelzo(int mennyiseg)
        {
            Console.WriteLine("Aktuális mennyiség: " + mennyiseg);
        }
    }
    class esemenykezeles_interface { 
    
        static void Main(string[] args)
        {
        IUzemanyagHelyzet jelzo = new Jelzo();
        Auto auto = new Auto(40, jelzo);

            auto.Verseny();

            Console.ReadLine();

    }
    }
}
