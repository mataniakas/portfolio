using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace IFF_8_2_AukstuolisM_L1a.Csharp
{
    class Executor
    {
        private DataMonitor data;
        private SortedResultMonitor result;
        public Executor(DataMonitor _data, SortedResultMonitor _result, int threadID)
        {
            data = _data;
            result = _result;
        }
        public void Launch()
        {
            while (true)
            {
                HDD removedItem = data.removeFirst();
                if (removedItem == null)
                {
                    break;
                }
                else 
                {
                    HDDWithComputedValue item = new HDDWithComputedValue(removedItem);
                    if (item.computedData > 10870)
                    {
                        result.addHDDSorted(item);
                    } 
                }
            }
        }
    }
}
