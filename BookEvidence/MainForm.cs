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
    public partial class MainForm : Form
    {
        int index;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshBookList();
        }

        private void RefreshBookList()
        {
            lstBooks.Items.Clear();
            foreach (Book book in Model.Books)
            {
                lstBooks.Items.Add(book);
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            FrmEditBook frmEditBook = new FrmEditBook();
            DialogResult result = frmEditBook.ShowDialog();
            if ( result == DialogResult.OK)
            {
                Book book = frmEditBook.Book;
                Model.Books.Add(book);
                RefreshBookList();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedIndex >= 0)
            {
                FrmEditBook frmEditBook = new FrmEditBook();
                frmEditBook.Book = Model.Books[lstBooks.SelectedIndex];
                DialogResult result = frmEditBook.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Model.Books[lstBooks.SelectedIndex] = frmEditBook.Book;
                    //nebo Book book = frmEditBook.Book;
                    RefreshBookList();
                }
            }
            else
            {
                MessageBox.Show("Select book to edit!", "Error!");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Do you want to delete selected book?", "Delete?", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Model.Books.RemoveAt(lstBooks.SelectedIndex);
                    RefreshBookList();
                }
                
            }
            else
            {
                MessageBox.Show("Select book to remove!", "Error!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Book database (*.dbd) |*.dbd|Všechny soubory (*.*)|*.*",
                Title = "Vyberte soubor pro databázi...",
            };

            var res = sfd.ShowDialog();
            if(res == DialogResult.OK)
            {
                string fileName = sfd.FileName;
                string tempName = System.IO.Path.GetTempFileName();
                string fileContent = GenerateFileContent();

                try
                {
                    System.IO.File.WriteAllText(tempName, fileContent);

                    System.IO.File.Copy(tempName, fileName, true);
                    System.IO.File.Delete(tempName);

                    MessageBox.Show("Books Saved Into File!");
                } catch(Exception ex)
                {
                    MessageBox.Show("Failed to save books!");
                }
            }
        }

        private string GenerateFileContent()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var book in Model.Books)
            {
                sb.Append(book.Author)
                    .Append(";")
                    .Append(book.Title)
                    .Append(";")
                    .Append(book.NumberOfPages)
                    .AppendLine();
            }

            return sb.ToString();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Book database (*.dbd) |*.dbd|Všechny soubory (*.*)|*.*",
                Title = "Vyberte soubor s databázi...",
            };

            var res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                string fileName = ofd.FileName;

                try
                {
                    string[] fileContent = System.IO.File.ReadAllLines(fileName);

                    LoadContentIntoTheModel(fileContent);

                    MessageBox.Show("Books Loaded From File!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load books!");
                }
            }

        }

        private void LoadContentIntoTheModel(string[] lines)
        {
            List<Book> books = new List<Book>();
            foreach(var line in lines)
            {
                string[] pts = line.Split(';');

                books.Add(new Book()
                {
                    Author = pts[0],
                    Title = pts[1],
                    NumberOfPages = int.Parse(pts[2])
                });
            }
            Model.Books.Clear();
            foreach(var book in books)
            {
                Model.Books.Add(book);
            }
            RefreshBookList();
        }
    }
}
