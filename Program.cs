using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticsToolsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string leaky = "";

            Console.WriteLine("Starting...");
            HashSet<string> strings = new HashSet<string>();
            HashSet<Worker> workers = new HashSet<Worker>();

            for (int i=0; i<100000; i++)
            {
                leaky += i.ToString();
                strings.Add(leaky);

                Worker w = new Worker();
                w.DoWork(i);

                workers.Add(w);

                System.Threading.Thread.Sleep(1);
            }
        }
    }

    public class Worker
    {
        public void DoWork(int i)
        {
            try
            {
                if (i % 500 == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }
                if (i % 1200 == 0)
                {
                    UseCPU();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Ignore it
            }
        }

        private void UseCPU()
        {
            var startTime = DateTime.Now;
            while (true)
            {
                if (DateTime.Now > startTime.AddMilliseconds(1500))
                {
                    break;
                }
            }
        }
    }
}
