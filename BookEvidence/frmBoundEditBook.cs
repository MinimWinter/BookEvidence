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
    public partial class frmBoundEditBook : Form
    {
        public frmBoundEditBook()
        {
            InitializeComponent();
        }

        public Book Book
        {
            get
            {
                return (Book)this.bookBindingSource.DataSource;
            }
            set
            {
                this.bookBindingSource.DataSource = value;
            }
        }
        private void frmBoundEditBook_Load(object sender, EventArgs e)
        {

        }
    }
}
