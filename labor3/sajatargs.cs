using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace labor3
{

    public class Auto2
    {
        public String Rendszam { get; set; }
    }

    class AutoEventArgs : EventArgs
    {
        public Auto2 Auto2 { get; set; }
    }

    class Szerviz
    {
        public delegate void JavitasEvendHandler(object src, AutoEventArgs args);
        public event JavitasEvendHandler Javitva;


        public void Javitas(Auto2 auto)
        {
            Console.WriteLine("Javitás is on...");
            Thread.Sleep(100);

            OnJavitva(auto);
        }

        protected virtual void OnJavitva(Auto2 auto)
        {
            if(Javitva != null)
            {
                Javitva(this, new AutoEventArgs() { Auto2 = auto });
            }
        }
    }

    class MailService
    {
        public void OnJavitva(object srv, AutoEventArgs autoEvent)
        {
            Console.WriteLine("[Mail] - {0} fr. számú készül", autoEvent.Auto2.Rendszam);
        }
    }
    class sajatargs
    {
    }
}
