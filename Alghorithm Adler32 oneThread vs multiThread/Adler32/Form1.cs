using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Designing of applications in ASP.NET
 * Author: Lukasz Janus
 * 31-05-2018
 * 
 * Program generuje losowe ciagi znakow (same male litery) o stalej dlugosci, wylicza wg funkcji Adler32 ich wartosc liczbowa,
 * a nastepnie sprawdza 'kazdy z kazdym' kolizje.
 * 
 * Dane wejsciowe: dlugosc ciagu i ilosc wyrazow.
 * Buttony dzialajace na oddzielnych watkach:
 * 1. Jednowatkowo - 'sekwencyjnie'.
 * 2. Wielowatkowo - na podstawie wykrytej liczby watkow w procesorze sprawdzanie kolizji jest rozbite na poszczegolne watki,
 *    Wyniki zapisywane sa do globalnych zmiennych, a po zakonczeniu pracy watkow
 * 
 * */

namespace Adler32
{
    public partial class Form1 : Form
    {
        Thread th1;
        Thread th2;

        //wspolne:
        UInt32 iMax;
        UInt32 n;

        //th1:
      //  static UInt32[] tab;
        Dictionary<UInt32, cAdler> Dane = new Dictionary<UInt32, cAdler>();
        //th2:
     //   static UInt32[] tab2;
        Dictionary<UInt32, cAdler> Dane2 = new Dictionary<UInt32, cAdler>();
        static UInt32 NumThreads = Convert.ToUInt32(Environment.ProcessorCount);
        static UInt32[] tCount = new UInt32[NumThreads]; //tablica na kawałki sumy 
        static UInt32[] portionResults; //tablica na kawalek obliczen
        static UInt32 portionSize; //liczba wartosci w procesie

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            label8_threads.Text = "Liczba wykrytych wątków: " + Convert.ToString(NumThreads);
        }

        /* button1 - jeden watek */

        private void button1_Click(object sender, EventArgs e)
        {
            th1 = new Thread(thread1);
            th1.Start();
        }

        /* button2 - wiele watkow */

        private void button2_Click(object sender, EventArgs e)
        {
            th2 = new Thread(thread2);
            th2.Start();

        }

        public void thread1()
        {
            //lock (this)
            // {
            Dane.Clear(); //czyszczenie przed ponownym uruchomieniem

            //ze StackOverflow - zmiana label, bez delegate wykrzaczala sie, bo label ida innym watkiem

            MethodInvoker inv = delegate
            {
                label4.Text = "";
                label5.Text = "";
                progressBar1.Value = 0;
                this.label4.Text = "Generowanie tablicy. Proszę czekać.";
                this.label5.Text = ("Przygotowanie licznika.");
            };
            this.Invoke(inv);

            //MessageBox.Show("Przygotowanie licznika");

            iMax = Convert.ToUInt32(sIloscWyrazow.Text);
            n = Convert.ToUInt32(sDlugoscCiagu.Text);

        //    tab = new UInt32[iMax];

            /* =========zapelnianie tablicy=============*/

            for (UInt32 i = 0; i < iMax; i++)
            {
                Dane.Add(i, new cAdler(n));

                for (UInt32 j = 0; j < n; j++)
                {
                    UInt32 temp = Convert.ToUInt32(rand.Next(26)) + 97;
                    // Console.WriteLine(Convert.ToString(temp)); //testowo
                    Dane[i].fnSetTekst(temp, j);

                }

                Dane[i].fnSetWynik(Dane[i].adler32());

                /*  ----- Diagnostyka - konsola ---- */

                /* ---------------- */
                /*
                Console.WriteLine("Adler: "+Convert.ToString(Dane[i].fnGetInt())); //testowo wynik liczbowy funkcji Adler
                Console.Write(Convert.ToString(i+", tekst: "));
                for (UInt32 j = 0; j < n; j++)
                {
                    Console.Write(Convert.ToString(Dane[i].fnGetTekst(j))); //testowo - podlglad wygenerowanego tekstu
                }
                Console.WriteLine("\n");
                */
                /* ---------------- */

            }
            MethodInvoker inv2 = delegate
            {
                label4.Text = "Szukanie kolizji jednowątkowo - prosze czekac.";
                label5.Text = ("Wyszukiwanie w toku...");
            };
            this.Invoke(inv2);
            //MessageBox.Show("Szukanie kolizji");

            /* ========= Szukanie kolizji po zapelnieniu tablicy - funkcja adler jeden watek =============*/

            float szerokosc = iMax / 100; //do paska postepu - szerokosc klasy
            DateTime startTime = DateTime.Now;  //stoper start
            UInt32 counter = 0;

            for (UInt32 i = 0; i < iMax; i += 1)
            {
                for (UInt32 j = iMax - 1; j > i; j -= 1)
                {
                    if (Dane[i].fnGetInt() == Dane[j].fnGetInt()) //porownoje tylko wartosci wyliczone przez metode adler32
                    {   //wyswietlanie zderzen:
                        //cout<<"Zderzone indeksy: i: "<< i<<", j: "<<j<<"\n";
                        //    cout << i << " " << j << "\n";
                        //cout<<" adler1: "<<Dane[i].fnGetTekst()<<", "<<Dane[i].fnGetInt()<<", adler2: "<<Dane[i].fnGetTekst()<<", "<<Dane[i].fnGetInt()<<"\n\n";
             //           tab[i] = Dane[i].fnGetInt();
                        //cout<<"bang";
                        counter++;
                    }
                }

                //pasek postepu:
                if (i % szerokosc == 0 && progressBar1.Value <= progressBar1.Maximum)
                {
                    MethodInvoker prog = delegate
                    {
                        progressBar1.Value++;
                    };
                    this.Invoke(prog);
                }
            }

            DateTime stopTime = DateTime.Now;
            TimeSpan roznica = stopTime - startTime;

            String l5 = "Czas pracy: " + Convert.ToString(roznica.TotalSeconds);
            String l6 = "Dla ciagu " + Convert.ToString(iMax) + " wyrazow o dlugosci " + Convert.ToString(n) + " znakow wykryto " + Convert.ToString(counter) + " kolizji.";
            MethodInvoker inv3 = delegate
            {
                label5.Text = (l5);
                label4.Text = (l6);
            };
            this.Invoke(inv3);
            counter = 0;

            MessageBox.Show("Singlethread Completed.");
            //}  //klamra do lock



        }

        /* Wiele watkow - automatycznie wykrywa ilosc watkow w procesorze */

        private void thread2()
        {
            // lock(this)
            // { 
            MethodInvoker inv = delegate
            {
                progressBar2.Value = 0;
                //               label7.Text = "";
                //                label6.Text = "";
                label6.Text = "Generowanie tablicy. Proszę czekać.";
                label7.Text = ("Przygotowanie licznika.");
            };
            this.Invoke(inv);

            Dane2.Clear(); //czyszczenie przed ponownym uruchomieniem
                           //  MessageBox.Show("Przygotowanie licznika");
            iMax = Convert.ToUInt32(sIloscWyrazow.Text);
            n = Convert.ToUInt32(sDlugoscCiagu.Text);

           // tab2 = new UInt32[iMax];

            /* =========zapelnianie tablicy=============*/

            for (UInt32 i = 0; i < iMax; i++)
            {
                Dane2.Add(i, new cAdler(n));

                for (UInt32 j = 0; j < n; j++)
                {
                    UInt32 temp = Convert.ToUInt32(rand.Next(26)) + 97;
                    // Console.WriteLine(Convert.ToString(temp)); //testowo
                    Dane2[i].fnSetTekst(temp, j);

                }

                Dane2[i].fnSetWynik(Dane2[i].adler32());

                /*  ----- Diagnostyka - konsola ---- */

                /* ---------------- */
                /*
                Console.WriteLine("Adler: "+Convert.ToString(Dane[i].fnGetInt())); //testowo wynik liczbowy funkcji Adler
                Console.Write(Convert.ToString(i+", tekst: "));
                for (UInt32 j = 0; j < n; j++)
                {
                    Console.Write(Convert.ToString(Dane[i].fnGetTekst(j))); //testowo - podlglad wygenerowanego tekstu
                }
                Console.WriteLine("\n");
                */
                /* ---------------- */

            }
            MethodInvoker inv2 = delegate
            {
                label6.Text = "Szukanie kolizji wielowątkowo - prosze czekac.";
                label7.Text = ("Wyszukiwanie w toku...");
            };
            this.Invoke(inv2);
            // MessageBox.Show("Szukanie kolizji");

            /* ========= Szukanie kolizji po zapelnieniu tablicy - funkcja adler wiele watkow watek =============*/
            DateTime startTime = DateTime.Now;  //stoper start

            //AdlerMulti();

            portionResults = new UInt32[Environment.ProcessorCount]; //tablica na wyniki cząstkowe wątków
            portionSize = iMax / NumThreads; //wyliczam szerokosc tablicy do watku


            Thread[] AdlerThreads = new Thread[NumThreads];

            //var consumingThread1 = new Thread(SumNumbers);
            for (UInt32 i = 0; i < NumThreads; i++)
            {
                AdlerThreads[i] = new Thread(AdlerMulti);
                AdlerThreads[i].Start(i);
            }
            for (UInt32 i = 0; i < NumThreads; i++)
            {
                AdlerThreads[i].Join(); //synchronizacja
            }
            UInt32 totalSum = 0;
            for (UInt32 i = 0; i < NumThreads; i++)
            {
                totalSum += tCount[i];
            }

            DateTime stopTime = DateTime.Now;
            TimeSpan roznica = stopTime - startTime;

            String l6 = Convert.ToString("Dla ciagu " + iMax + " wyrazow o dlugosci " + n + " znakow wykryto " + totalSum + " kolizji.");
            String l7 = Convert.ToString("Czas pracy: " + roznica.TotalSeconds);

            MethodInvoker inv3 = delegate
            {
                label6.Text = l6;
                label7.Text = l7;
            };
            this.Invoke(inv3);



            MessageBox.Show("Multithread Completed.");
            //  } //klarma do lock
        }

        /* ======  klasa adler - wielowatkowe szukanie kolizji ====== */

        private void AdlerMulti(object portionNumber) //UInt32 zamiast object rowniez dziala - sprawdzic roznice
        {
            //lock(this) //lock w tym miejscu blokuje drugi watek
            //{ 
                UInt32 counter = 0;

                UInt32 portionNumberAsInt = (UInt32)portionNumber;
                UInt32 baseIndex = portionNumberAsInt * portionSize; //0 dla pierwszej porcji, 1*size dla drugiej, 2*size dla trzeciej itp itd

                float szerokosc = iMax / 100; //do paska postepu - szerokosc klasy //do ProgresBar2

                for (UInt32 i = baseIndex; i < baseIndex + portionSize; i++)
                {
                    for (UInt32 j = iMax - 1; j > i; j -= 1)
                    {
                        if (Dane2[i].fnGetInt() == Dane2[j].fnGetInt()) //porownoje tylko wartosci wyliczone przez metode adler32
                        {   //wyswietlanie zderzen:
                            //cout<<"Zderzone indeksy: i: "<< i<<", j: "<<j<<"\n";
                            //    cout << i << " " << j << "\n";
                            //cout<<" adler1: "<<Dane[i].fnGetTekst()<<", "<<Dane[i].fnGetInt()<<", adler2: "<<Dane[i].fnGetTekst()<<", "<<Dane[i].fnGetInt()<<"\n\n";
                           // tab2[i] = Dane2[i].fnGetInt(); //tab2 - do wyswietlenia wartosci adler
                            //cout<<"bang";

                            counter++; //licznik zderzen
                        }
                    }

                    //pasek postepu:
                    if (i % szerokosc == 0 && progressBar1.Value <= progressBar1.Maximum)
                    {
                        MethodInvoker prog = delegate
                        {
                           progressBar2.Value++;
                        };
                        this.Invoke(prog);
                    }
                }

            
                tCount[(UInt32)portionNumberAsInt] = counter;
           // }  //lock

        }
    }
}
