using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookEvidence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bookBindingSource.DataSource = Model.Books;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBoundEditBook frm = new frmBoundEditBook()
            {
                Book = new Book()

            };
            var res = frm.ShowDialog();
            if(res == DialogResult.OK)
            {
                Book book = frm.Book;
                Model.Books.Add(book);
               // bookBindingSource.ResetBindings(false);
            }
        }

        private void lstBooks_DoubleClick(object sender, EventArgs e)
        {
            Book book = lstBooks.SelectedItem as Book;
            if (book == null) return;

            frmBoundEditBook frm = new frmBoundEditBook()
            {
                Book = book
            };
            var res = frm.ShowDialog();

        }
    }
}
