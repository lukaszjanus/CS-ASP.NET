using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adler32
{
    internal class cAdler
    {
        public UInt32 nn;
        //char tekst[5]={'t','e','s','t','\0'}; //dla testu
        public char[] tekst;// = new char[n];
        public UInt32 wynik;

        

        public cAdler(UInt32 n)
        {
            nn = n;
           // MessageBox.Show(Convert.ToString(nn));
           // Console.WriteLine(Convert.ToString(nn));
            tekst = new char[nn];
                        
        }
        ~cAdler() { }

        public UInt32 adler32() //metoda wyliczajaca wartosc wg adler32
        {
            UInt32 A = 1;
            UInt32 B = 0;

            for (UInt32 i = 0; i < nn; i++)
            {
                A = (A + tekst[i]) % 65521;
                B = (B + A) % 65521;
            }

            return B * 65536 + A;
        }
        
        public void fnSetTekst( UInt32 t, UInt32 i )
        {
            tekst[i] = Convert.ToChar(t);
        }
       
        
        public char fnGetTekst(UInt32 j)
        {
            return tekst[j];
        }
        
        public void fnSetWynik( UInt32 w )
        {
            wynik = w;
        }
        public UInt32 fnGetInt()
        {
            return wynik;
        }
    }
}