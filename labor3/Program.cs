using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor3
{

    //Eseménykezelés
    //Delegált

    public delegate void Metodusok(string x);

    class Program
    {

        static void MetodusEgy(string a)
        {
            Console.WriteLine(">>" + a);
        }

        static void MetodusKetto(string b)
        {
            Console.WriteLine(":::" + b);
        }

        static void MetodusHarom(string c)
        {
            Console.WriteLine("---" + c);
        }

        static void MetodusNegy(string d)
        {
            Console.WriteLine("+++" + d);
        }
        static void Main(string[] args)
        {
           // MetodusEgy("alma");
            //MetodusKetto("körte");


            Metodusok met = new Metodusok(MetodusEgy);
            met += MetodusKetto; //feliratkozás
            met += MetodusHarom;
            met += MetodusNegy;

            met -= MetodusEgy;  //leiratkozás

            met("hideg van");
            Console.ReadLine();
        }
    }
}
