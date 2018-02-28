using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace labor3

	//esemenykezeles with : delegate, interface, event
{
	class Auto
    {
		public string Rendszam { get; set; }
    }

    class Szerviz
    {
        // 3 lépés:
        // 1. definiáljuk a delegáltat
        // 2. esemény delegált alapján
        // 3. esemény elsütése

        public delegate void JavitasEventHandler(object source, EventArgs args);
        public event JavitasEventHandler Javitva;

        public void Javitas(Auto auto)
        {
            Console.WriteLine("Autó javítása....");
            Thread.Sleep(1000);

            OnJavitva();
        }

        protected virtual void OnJavitva()
        {
            if (Javitva != null)
            {
                Javitva(this, EventArgs.Empty);
            }
        }
    }

	class MailService
    {
		public void onJavitva(object source, EventArgs args)
        {
            Console.WriteLine("[MAIL] - Az autó kész.");
        }
    }

	class FacebookService
    {
		public void OnJavitva(object source, EventArgs args)
        {
            Console.WriteLine("[FB] - Az autó kész");
        }
    }

    class esemenykezeles_event
    {

        static void Main(string[] args)
        {
            Szerviz szerviz = new Szerviz();
            Auto auto = new Auto() { Rendszam = "ASD123" };

            MailService ms = new MailService();
            FacebookService fs = new FacebookService();

            //a lényeg: 
            szerviz.Javitva += ms.onJavitva;
            szerviz.Javitva += fs.OnJavitva;

            szerviz.Javitas(auto);
	
            Console.ReadLine();

        }
    }
}
