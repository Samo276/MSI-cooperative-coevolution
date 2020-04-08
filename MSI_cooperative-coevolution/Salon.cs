using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI_cooperative_coevolution
{
    public class Salon

    {
        static int rodzajow_samochodow = 8;
        public int[,] modele = new int[rodzajow_samochodow, 8];
        public int[] zapotrzebowanie = new int[rodzajow_samochodow]; // czyli ilosc samochodow z takimi komponentami jaka zostala zamowiona
        public int[] najbardziej_pozadane_komponenty = new int[rodzajow_samochodow];
        public int[] fitness = new int[rodzajow_samochodow];
        //Samochod modele 
        /* _________________________________________
        *  |__________oznaczenia_wartosci:__________| 
         * |_____0_______________|______1___________|
         0.| heatchback          |    coupe         |
         1.| disel               |    benz          |
         2.| bez                 |    klima         |
         3.| srzynia auto        |    manual        |
         4.| szyby elektryczne   |    manual        |
         5.| radio blutoot       |    classyczne    |
         6.| szyberdach          |    brak          |
         7.| komputer pokładowy  |    brak          |
        
         */

    }
}
