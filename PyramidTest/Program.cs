using System;
using System.Collections.Generic;
using System.IO;

namespace PyramidTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Masaustundeki .txt dosyasindan piramit yapisi cekildi.
            string path = @"C:\Users\x\Desktop\input.txt";

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);

            string word = sw.ReadLine();

            //Liste ve arrayler kullanilarak piramit nesnesi olusturuldu.
            List<string[]> pyramid = new List<string[]>();
            
            //Piramit nesnesine .txt dosyasindaki yapi eklendi.
            while (word != null)
            { 
                string[] tempArray = word.Split(' ');
                pyramid.Add(tempArray);
                word = sw.ReadLine();
            }

            sw.Close();
            fs.Close();

            //Toplamlarin karsilastirilmasi icin sums listesi olusturuldu.
            List<int> sums = new List<int>();

            //Piramitte gezinme fonksiyonu cagirilarak sums listesine toplamlar eklendi.
            searchInPyramid(pyramid, 0, 0, 0, sums);

            //Konsolda algoritmanin dogrulugu test edildi.
            Console.WriteLine(maxSum(sums)); 

            
        }
        static bool isItPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }
            int x, j; 
             
                x = 2;
                j = 0;
               
                while (x != (int)(Math.Sqrt(number)) + 1)
                {
                    if (number % x == 0)
                    {
                        j = 1;
                        break; 
                    }
                    else x++;
                }
            if (j == 0)
                return true; 

            return false;
        }
        static void searchInPyramid(List<string[]> pyramid,int pyramidIndex,int arrayIndex,int sum,List<int> sums) {
            /*
             Algoritma recursive yapidadir. Ikili arama agacindaki searching algoritmasindan esinlenilmistir.
             pyramidIndex parametresi piramit basamaklarin gezilmesi ve recursive yapinin bozulmasi icin, arrayIndex parametresi
             piramit basamaklarindaki elemanlarin gezilmesi icin olusturulmustur.
             */


            //Recursive yapinin durdurulmasi

            if (pyramid.Count == pyramidIndex)
            {
                //Piramitin en alt basamaginda sol ve sag degerlerin varligi ayri ayri kontrol edildigi icin sums listesine 2 kere ekleme yapiliyor.
                //2 Kere eklenilmesi onlenildi.  

                if (!sums.Contains(sum))
                    sums.Add(sum);
            }
            else
            {
                int value = Convert.ToInt32(pyramid[pyramidIndex][arrayIndex]);

                if (!isItPrime(value))
                {
                    sum += value;
                    pyramidIndex++;
                    searchInPyramid(pyramid, pyramidIndex, arrayIndex, sum, sums);

                    searchInPyramid(pyramid, pyramidIndex, arrayIndex + 1, sum, sums);
                }
            }   
        }
        static int maxSum(List<int> sums)
        {
             sums.Sort();
            return sums[sums.Count-1];
        }

    }
}
