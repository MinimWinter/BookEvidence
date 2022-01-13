using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEvidence
{
    public static class Model
    {
        public static BindingList<Book> Books { get; set; } = new BindingList<Book>();
    }
}
