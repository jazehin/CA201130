using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201130
{
    struct Eredmeny
    {
        public int Helyezes;
        public int Letszam;
        public string Sportag;
        public string Versenyszam;

        public Eredmeny(string sor)
        {
            var t = sor.Split(' ');

            this.Helyezes = int.Parse(t[0]);
            this.Letszam = int.Parse(t[1]);
            this.Sportag = t[2];
            this.Versenyszam = t[3];
        }
    }
    class Program
    {
        static List<Eredmeny> eredmenyek = new List<Eredmeny>(200);
        static void Main()
        {
            F2();
            F3();
            F4();
            F5();
            F6();
            F7();
            F8();
            Console.ReadKey();
        }

        private static void F8()
        {
            int maxi = 0;
            for (int i = 1; i < eredmenyek.Count; i++)
            {
                if (eredmenyek[i].Letszam > eredmenyek[maxi].Letszam) maxi = i;
            }
            Console.WriteLine($"8. feladat\nHelyezés: {eredmenyek[maxi].Helyezes}\nSportág: {eredmenyek[maxi].Sportag}\nVersenyszám: {eredmenyek[maxi].Versenyszam}\nSportolók száma: {eredmenyek[maxi].Letszam}");
        }

        private static void F7()
        {
            var sw = new StreamWriter(@"..\..\Res\helsinki2.txt", false, Encoding.UTF8);
            

            foreach (var e in eredmenyek)
            {
                string t = "";
                t += $"{e.Helyezes} {e.Letszam} ";
                switch (e.Helyezes)
                {
                    case 1:
                        t += 7;
                        break;
                    case 2:
                        t += 5;
                        break;
                    case 3:
                        t += 4;
                        break;
                    case 4:
                        t += 3;
                        break;
                    case 5:
                        t += 2;
                        break;
                    case 6:
                        t += 1;
                        break;
                }
                t += $" {e.Sportag.Replace("kajakkenu", "kajak-kenu")} {e.Versenyszam}";
                sw.WriteLine(t);
            }

            sw.Flush();
            sw.Close();
        }

        private static void F6()
        {
            int uszas = 0, torna = 0;

            foreach (var e in eredmenyek)
            {
                if (e.Helyezes <= 3 && e.Sportag == "torna") torna++;
                else if (e.Helyezes <= 3 && e.Sportag == "uszas") uszas++;
            }

            if (torna > uszas) Console.WriteLine("6. feladat:\nTorna sportágban szereztek több érmet");
            else if (uszas > torna) Console.WriteLine("6. feladat:\nÚszás sportágban szereztek több érmet");
            else Console.WriteLine("6. feladat:\nEgyenlő volt az érmek száma");
        }

        private static void F5()
        {
            int pont = 0;
            foreach (var e in eredmenyek)
            {
                switch (e.Helyezes)
                {
                    case 1:
                        pont += 7;
                        break;
                    case 2:
                        pont += 5;
                        break;
                    case 3:
                        pont += 4;
                        break;
                    case 4:
                        pont += 3;
                        break;
                    case 5:
                        pont += 2;
                        break;
                    case 6:
                        pont += 1;
                        break;
                }
            }

            Console.WriteLine($"5. feladat:\nOlimpiai pontok száma: {pont}");
        }

        private static void F4()
        {
            Console.WriteLine("4. feladat:");
            int[] ermek = { 0, 0, 0 };

            for (int i = 0; i < eredmenyek.Count; i++)
            {
                if (eredmenyek[i].Helyezes <= 3) ermek[eredmenyek[i].Helyezes - 1]++;
            }

            Console.WriteLine($"Arany: {ermek[0]}\nEzüst: {ermek[1]}\nBronz: {ermek[2]}\nÖsszesen: {ermek.Sum()}");
        }

        private static void F3()
        {
            Console.WriteLine($"3. feladat:\nPontszerző helyezések száma: {eredmenyek.Count}");
        }

        private static void F2()
        {
            var sr = new StreamReader(@"..\..\Res\helsinki.txt");

            while (!sr.EndOfStream) eredmenyek.Add(new Eredmeny(sr.ReadLine()));

            sr.Close();
        }
    }
}
