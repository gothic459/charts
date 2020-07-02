using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charts
{
    public class Obiekt
    {
        private string nazwa;
        private int czasTrwania;
        private string poprzednicy;
        private Obiekt[] arr = new Obiekt[1024];

        public Obiekt(string nazwa, int czasTrwania, string poprzednicy)
        {
            this.nazwa = nazwa;
            this.czasTrwania = czasTrwania;
            this.poprzednicy = poprzednicy;
        }

        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
        public int CzasTrwania
        {
            get { return czasTrwania; }
            set { czasTrwania = value; }
        }
        public string Poprzednicy
        {
            get { return poprzednicy; }
            set { poprzednicy = value; }
        }

        public Obiekt this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }

        }



    }
}



