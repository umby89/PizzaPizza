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
        public static int numeroGiri { get; private set; }
        public static int ciclo { get; private set; }

        static void Main(string[] args)
        {
            int somma = 0;
            int obiettivo = 100;
            int[] arrayInt = new int[10];
            arrayInt[0] = 4;
            arrayInt[1] = 14;
            arrayInt[2] = 15;
            arrayInt[3] = 18;
            arrayInt[4] = 29;
            arrayInt[5] = 32;
            arrayInt[6] = 36;
            arrayInt[7] = 82;
            arrayInt[8] = 95;
            arrayInt[9] = 95;
            List<string> bestValue = new List<string>();

            for ( i = 0; i < arrayInt.Length; i++)
            {
                somma = arrayInt[i];
                bestValue.Add(i.ToString()+"-Indice");
                if (i + 1 < arrayInt.Length)
                {
                    ciclo = i + 1;
                    for ( j = i + 1; j < arrayInt.Length; j++)
                    {
                       
                        somma = somma + arrayInt[j];
                        if (somma <= obiettivo)
                        {
                            bestValue.Add(j.ToString() + "-Indice");
                        }
                        else
                        {
                            bestValue.Add((somma - arrayInt[j]).ToString()+":Valore");
                            if (somma - arrayInt[j] == obiettivo)
                            {
                                trovaIlMassimo(bestValue);
                            }
                            j = ciclo++;
                            somma = arrayInt[i];
                            bestValue.Add(i.ToString() + "-Indice");

                        }
                    }
                }      
                else
                {
                    j = arrayInt.Length;
                }
                if(i+1 == arrayInt.Length)
                {
                    trovaIlMassimo(bestValue);
                }
            }

        }

        private static void trovaIlMassimo(List<string> bestValue)
        {
            throw new NotImplementedException();
        }
    }
}
