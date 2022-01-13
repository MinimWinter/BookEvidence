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
    public partial class FrmEditBook : Form
    {
        public FrmEditBook()
        {
            InitializeComponent();
        }

        private Book book = new Book();

        public Book Book
        {
            get
            {
                book.Author = txtAuthor.Text;
                book.Title = txtTitle.Text;
                book.NumberOfPages = (int)nmrPages.Value;
                return book;
            }

            set
            {
                this.book = value;
                txtTitle.Text = value.Title;
                txtAuthor.Text = value.Author;
                nmrPages.Value = value.NumberOfPages;
            }
        }

        private void FrmEditBook_Load(object sender, EventArgs e)
        {

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
