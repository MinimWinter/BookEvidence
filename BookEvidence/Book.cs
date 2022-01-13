using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEvidence
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }

        public string DisplayTitle { get => $"{Author} : {Title}";}
        public override string ToString()
        {
            return $"{Author}-{Title}-({NumberOfPages} pages)";
        }
    }
}
