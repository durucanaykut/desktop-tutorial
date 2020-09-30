using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAndSentenceCount
{
    class WordCounter
    {
        static void Main()
        {
            string inFileName = null;

            Console.WriteLine("Enter the name of the file to process:");
            inFileName = Console.ReadLine();

            StreamReader sr = new StreamReader(inFileName);

            int temp;
            string temp2;
            int sentencesCounter = 0;
            int avg = 0;
            string SentenceDelim = ".?!:";
            string wordDelim = "\r\n.?!: ,;";
            string[] sentenceFields = null;
            string[] wordFields = null;
            string[] arrFields = null;
            int[] arrCounts = null;
            string line = null;
            int count = 1;
            int total = 0;
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();

            while (!sr.EndOfStream)
            {
                line = line + sr.ReadLine();
            }



            sentenceFields = line.Split(SentenceDelim.ToCharArray());
            for (int i = 0; i < sentenceFields.Length - 1; i++)
            {
                sentencesCounter++;
                
            }
            wordFields = line.Split(wordDelim.ToCharArray());
            wordFields = wordFields.Where(w => w.ToString() != "").ToArray();
            int n = wordFields.Length;
            avg = n / sentencesCounter;

            for (int i = 0; i < n; i++)
            {
                count = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (wordFields[i] == wordFields[j])
                    {
                        count++;
                    }
                }
                list.Add(wordFields[i]);
                list2.Add(count);
                wordFields = wordFields.Where(w => w.ToString() != wordFields[i]).ToArray();
                i = -1;
                n = wordFields.Count();
            }
            arrFields = list.ToArray();
            arrCounts = list2.ToArray();
            for (int i = 0; i < arrCounts.Length - 1; i++)
                for (int j = i + 1; j < arrCounts.Length; j++)
                    if (arrCounts[i] < arrCounts[j])
                    {

                        temp = arrCounts[i];
                        arrCounts[i] = arrCounts[j];
                        arrCounts[j] = temp;
                        temp2 = arrFields[i];
                        arrFields[i] = arrFields[j];
                        arrFields[j] = temp2;
                    }
            sr.Close();
            Console.WriteLine("Sentence Count : "+ sentencesCounter);
            Console.WriteLine("Avg. Word Count  : "+ avg);
            for(int i = 0; i < arrFields.Length; i++)
            {
                Console.WriteLine(arrFields[i] + " " + arrCounts[i]);
            }
            Console.ReadKey();
        }
    }
}

