using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPizza
{
    class Program
    {
        public static int i { get; private set; }
        public static int j { get; private set; }
        public static int cicle { get; private set; }
        public static string stringOfIndex { get; private set; }
        public static string[] listOfIndex { get; private set; }
        public static int value { get; private set; }
        public static int maxValue { get; private set; }

        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\umber\Source\Repos\umby89\PizzaPizza\input\c_medium.in");

            string[] splitLine1 = lines[0].Split(' ');
            string[] splitLine2 = lines[1].Split(' ');
            int maxSlice = Convert.ToInt32(splitLine1[0]);
            int typeOfPizza = Convert.ToInt32(splitLine1[1]);
            int[] pizzaValue =  splitLine2.Select(int.Parse).ToArray();
            int sum = 0;                   
            List<string> bestValue = new List<string>();

            for ( i = 0; i < pizzaValue.Length; i++)
            {
                sum = pizzaValue[i];
                bestValue.Add(i.ToString()+"-Indice");
                if (i + 1 < pizzaValue.Length)
                {
                    cicle = i + 1;
                    for ( j = i + 1; j < pizzaValue.Length; j++)
                    {
                       
                        sum = sum + pizzaValue[j];
                        if (sum <= maxSlice)
                        {
                            bestValue.Add(j.ToString() + "-Indice");
                            if (j+1 == pizzaValue.Length)
                            {
                                bestValue.Add(sum.ToString());
                                break;
                            }
                        }
                        else
                        {
                            bestValue.Add((sum - pizzaValue[j]).ToString());
                            if (sum - pizzaValue[j] == maxSlice)
                            {
                                findMax(bestValue);
                                break;
                            }
                            j = cicle++;
                            sum = pizzaValue[i];
                            bestValue.Add(i.ToString() + "-Indice");
                        }
                    }
                }      
                else
                {
                    j = pizzaValue.Length;
                }
              
            }
            if (i == pizzaValue.Length)
            {
                findMax(bestValue);
            }
        }

        //metodo per estrarre il massimo valore e indici allegati dalla lista
        private static void findMax(List<string> bestValue)
        {
            for (int z = 0; z < bestValue.Count; z++)
            {
                if (!bestValue[z].Contains("Indice"))
                {
                    value = Convert.ToInt32(bestValue[z]);
                    if (value > maxValue)
                        maxValue = value;
                }
            }

            for (int x = bestValue.Count-1; x > 0; x--)
            {
                if (bestValue[x].Contains(maxValue.ToString()))
                {
                    for (int y = x; y > 0; y--)
                    {
                        if (bestValue[y-1].Contains("Indice"))
                        {
                            stringOfIndex = stringOfIndex + "-" + bestValue[y-1];
                        }
                        else
                        {
                            y = 0;
                        }
                    }
                }
               
            }
            stringOfIndex = stringOfIndex.Replace("Indice", "/").Replace("-", "");
            listOfIndex = stringOfIndex.Split('/'); // INDICI per ottenere il massimo risultato
                                                    //Gestione stringe indici per trovare i valori che compongono il valore max
        }
    }
}
