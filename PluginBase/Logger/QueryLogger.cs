using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.Logger
{
    public class QueryLogger : IQueryLogger
    {
        private event EventHandler? Notify;

        public void AddEventHandler(EventHandler handler) => Notify += handler;

        public void Log(string query)
        {
            try
            {
                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    sw.WriteLine($"{DateTime.Now}: {query}");
                    Notify?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
