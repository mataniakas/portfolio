using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace IFF_8_2_AukstuolisM_L1a.Csharp
{
    class DataMonitor
    {
        public HDD[] array;
        public int counter;
        private readonly int MIN_VALUE = 0;
        private int MAX_VALUE;
        private readonly object mutex;
        private bool isLast;
        public DataMonitor(int n)
        {
            array = new HDD[n/2];
            counter = 0;
            mutex = new object();
            isLast = false;
            MAX_VALUE = n / 2;
        }
        public void addHDD(HDD hdd, bool last)
        {
            lock(mutex)
            {
                while (counter >= MAX_VALUE)
                {
                    Monitor.Wait(mutex);
                }
                if(last)
                {
                    isLast = true;
                    Monitor.PulseAll(mutex);
                }
                array[counter] = hdd;
                counter++;
                Monitor.PulseAll(mutex);
            }
        }
        public HDD removeFirst()
        {
            HDD removedItem = new HDD();
            lock (mutex)
            {
                while (counter <= MIN_VALUE && !isLast)
                {
                    Monitor.Wait(mutex);
                }
                if(counter<=0)
                {
                    Monitor.PulseAll(mutex);
                    return null;
                }
                else
                {
                    removedItem = array[0];
                    for (int i = 0; i < counter - 1; i++)
                        array[i] = array[i + 1];
                    counter--;
                    Monitor.PulseAll(mutex);
                    return removedItem;
                }
            }
        }
    }
}


