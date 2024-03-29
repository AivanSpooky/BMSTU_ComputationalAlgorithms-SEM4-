using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace lab_02
{
    internal static class Program
    {
        
    [STAThread]
        static void Main()
        {
            Debug.WriteLine("Started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
