using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TaskManager
{
    class ProcessToView
    {
        public string Name { set; get; }
        public int ID { set; get; }
        public int CountThreads { set; get; }
        public double MemoryMB { set; get; }

        public ProcessToView(int id, String Name, int CountThreads, double MemoryMB)
            {
                this.Name = Name;
                this.ID = id;
                this.CountThreads = CountThreads;
                this.MemoryMB = MemoryMB;
            }
        public static List<ProcessToView> GetProcesses()
        {
            List<Process> list = Process.GetProcesses().ToList();
            List<ProcessToView> ListFinal = new List<ProcessToView>();
            foreach (var e in list)
            {
                ListFinal.Add(new ProcessToView(e.Id, e.ProcessName, e.Threads.Count, Math.Round(((e.WorkingSet64 / 1024.0f) / 1024.0f), 2)));
            }
            return ListFinal;
        }
    }
}
