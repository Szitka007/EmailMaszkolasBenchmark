using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;
using System.Text;

namespace EmailCimMaszkolasTesztek
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<EmailMaszkolo>();
            EmailMaszkolo asd = new EmailMaszkolo();
            asd.ForCiklussalOsszefuzve();
            asd.CharArrayEsNewString();
            Console.ReadKey();
        }
    }

    [MemoryDiagnoser]
    class EmailMaszkolo
    {
        string email = "gambit@umszki.hu";

        [Benchmark]
        public void ForCiklussalOsszefuzve()
        {
            string maszkolt = "";
            bool voltkukac = false;
            for (int i = 0; i < email.Length; i++)
            {
                if (!voltkukac)
                {
                    if (i <= 2)
                    {
                        maszkolt += email[i];
                    }
                    else if (i > 2)
                    {
                        maszkolt += '*';
                    }
                    if (email[i+1] == '@')
                    {
                        voltkukac = true;
                    }
                }
                else if (voltkukac)
                {
                    maszkolt += email[i];
                }
            }
            Console.WriteLine(maszkolt);
        }


        [Benchmark]
        public void CharArrayEsNewString()
        {
            int i = 3;
            bool voltkukac = false;
            char[] darabolt = email.ToCharArray();
            do
            {
                darabolt[i] = '*';
                if (darabolt[i+1]=='@')
                {
                    voltkukac = true;
                }
                i++;
            } while (!voltkukac);
            string maszkolt = new string(darabolt);
            Console.WriteLine(maszkolt);
        }

        [Benchmark]
        public void StringBuilderrel()
        {
            StringBuilder valami = new StringBuilder();
            
        }

        [Benchmark]
        public void NewStringKonstruktorral()
        {

        }


        [Benchmark]
        public void StringPontParancsokkal()
        {

        }

    }
}
