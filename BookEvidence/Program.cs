using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookEvidence
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Model.Books.Add(new Book()
            {
                Title = "Narnie",
                Author = "C. S. Lewis",
                NumberOfPages = 250
            });

            Model.Books.Add(new Book()
            {
                Title = "Spalovač Mrtvol",
                Author = "Ladislav Fuks",
                NumberOfPages = 340
            });


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new MainForm());
        }
    }
}
