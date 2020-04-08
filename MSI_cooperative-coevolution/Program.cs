using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI_cooperative_coevolution
{
    class Program
    {
        static int rodzajow_samochodow = 100;
        static int ilosc_salonow = 4;
        static void Main(string[] args)
        {
            Spis_salonow salony = new Spis_salonow();
            Random rng = new Random();

            //generuje zapotrzebowanie w salonie
            for (int j = 0; j < ilosc_salonow; j++)
                for (int i = 0; i < rodzajow_samochodow; i++)
                    salony.lista_salonow[j].zapotrzebowanie[i] = rng.Next(0, 100);

            //generuje rodzaje zamowionych przez klientow samochodów
            for (int k = 0; k < ilosc_salonow; k++)
                for (int i = 0; i < rodzajow_samochodow; i++)
                    for (int j = 0; j < rodzajow_samochodow; j++)
                        salony.lista_salonow[k].modele[i, j] = rng.Next(0, 1);

            //wyznaczenie najbardziej pozadanych komponentow w samochadach w danym salonie salonu (fitness)
            for (int i = 0; i < ilosc_salonow; i++)
                salony.lista_salonow[i].najbardziej_pozadane_komponenty = Wyznaczanie_najbardziej_pozodanych_cech_samochodu_w_salone(salony.lista_salonow[i]);

            //obliczenie fitnesu dla każdego samochodu w salonie
            for (int i = 0; i < ilosc_salonow; i++)
                for (int j = 0; j < rodzajow_samochodow; j++)
                    for (int k = 0; k < rodzajow_samochodow; k++)
                        if (salony.lista_salonow[i].najbardziej_pozadane_komponenty[k] == salony.lista_salonow[i].modele[j, k]) salony.lista_salonow[i].fitness[j]++;

            Console.WriteLine("OK");
            Console.ReadLine();
        }


        static int[] Wyznaczanie_najbardziej_pozodanych_cech_samochodu_w_salone(Salon nr_salonu)
        {
            int[] wzor = new int[8];
            for (int i = 0; i < 8; i++)
            {
                wzor[i] = 0;
            }

            for (int j = 0; j < 8; j++)
                for (int i = 0; i < rodzajow_samochodow; i++)
                    if (nr_salonu.zapotrzebowanie[i] != 0)
                    {
                        if (nr_salonu.modele[i, j] == 0) wzor[j] -= nr_salonu.zapotrzebowanie[i];
                        else wzor[j] += nr_salonu.zapotrzebowanie[i];
                    }

            for (int i = 0; i < 8; i++)
            {
                if (wzor[i] <= 0) wzor[i] = 0;
                else wzor[i] = 1;
            }
            return wzor;
        }
        //generowanie samochopdow
        //generowanie zapotrzebowania
    }
}

