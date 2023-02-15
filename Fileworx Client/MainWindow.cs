using FileworxObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fileworx_Client
{
    public partial class MainWindow : Form
    {
        int selectedRow;
        DataTable NewsTable;
        DataTable PhotoTable;

        public static bool categoryChanged = false;
        public static bool dateChanged = false;

        NewsQuery nq = new NewsQuery();
        PhotoQuery pq = new PhotoQuery();

        static string mod;

        public enum categories
        {
            General,
            Politics,
            Sports,
            Health

        }

        public MainWindow()
        {
            InitializeComponent();


            this.WindowState = FormWindowState.Maximized;

            foreach (categories cat in Enum.GetValues(typeof(categories)))
            {
                txtCategory.Items.Add(cat.ToString());

            }

            txtCreated.MaxDate = DateTime.Now;
            updateTable();

        }
        public MainWindow(string m)
        {
            InitializeComponent();


            this.WindowState = FormWindowState.Maximized;

            foreach (categories cat in Enum.GetValues(typeof(categories)))
            {
                txtCategory.Items.Add(cat.ToString());

            }
            mod= m;

            txtCreated.MaxDate = DateTime.Now;
            updateTable();

        }


        public void updateTable()
        {

            NewsTable = nq.ReadAll();
            PhotoTable = pq.ReadAll();


            NewsTable.Merge(PhotoTable);
            GridView.DataSource = NewsTable;

            GridView.Columns[5].Visible = false;
            GridView.Columns[6].Visible = false;
            GridView.Columns[7].Visible = false;
            GridView.Columns[8].Visible = false;

        }

        private void GridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            selectedRow = e.RowIndex;
            tabControlMain.TabPages.Remove(imageTab);
            if (selectedRow != -1)
            {

                txtTitle.Text = GridView.Rows[selectedRow].Cells[1].Value.ToString();
                txtCreated.Text = GridView.Rows[selectedRow].Cells[2].Value.ToString();
                txtBody.Text = GridView.Rows[selectedRow].Cells[4].Value.ToString();
                int id = int.Parse(GridView.Rows[selectedRow].Cells[0].Value.ToString());
                string desc = GridView.Rows[selectedRow].Cells[3].Value.ToString();

                if (GridView.Rows[selectedRow].Cells[8].Value.ToString() == String.Empty)
                {

                    txtCategory.Visible = true;
                    txtCategory.Text = GridView.Rows[selectedRow].Cells[7].Value.ToString();
                    lblCategory.Visible = true;

                }
                else
                {
                    txtCategory.Visible = false;
                    lblCategory.Visible = false;
                    tabControlMain.TabPages.Add(imageTab);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.ImageLocation = txtCategory.Text = GridView.Rows[selectedRow].Cells[8].Value.ToString();

                }

                if (e.Button == MouseButtons.Right)
                {
                    DialogResult res = MessageBox.Show($"are you sure you want to delete {txtTitle.Text} with id of {id}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        if (GridView.Rows[selectedRow].Cells[8].Value.ToString() == String.Empty)
                        {
                            News t = new News(txtTitle.Text, DateTime.Parse(txtCreated.Text), desc, txtCategory.Text, txtBody.Text, id);
                            t.Delete();


                        }
                        else
                        {
                            Photo t = new Photo(txtTitle.Text, DateTime.Parse(txtCreated.Text), desc, pictureBox.ImageLocation, txtBody.Text, id);
                            t.Delete();
                        }
                        updateTable();
                    }
                }

            }
        }

        private void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = GridView.CurrentCell.RowIndex;
            int id = int.Parse(GridView.Rows[selectedRow].Cells[0].Value.ToString());
            string desc = GridView.Rows[selectedRow].Cells[3].Value.ToString();
            if (GridView.Rows[selectedRow].Cells[8].Value.ToString() == String.Empty)
            {
                News t = new News(txtTitle.Text, DateTime.Parse(txtCreated.Text), desc, txtCategory.Text, txtBody.Text, id);
                CreateNewsWindow f1 = new CreateNewsWindow(this, t);
                f1.Show();

            }
            else
            {
                Photo t = new Photo(txtTitle.Text, DateTime.Parse(txtCreated.Text), desc, pictureBox.ImageLocation, txtBody.Text, id);
                CreatePhotosWindow f1 = new CreatePhotosWindow(this, t);
                f1.Show();
            }
        }



        private void newsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewsWindow f1 = new CreateNewsWindow(this, null);
            f1.Show();

        }

        private void photoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePhotosWindow f1 = new CreatePhotosWindow(this, null);
            f1.Show();

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUserWindow f1 = new CreateUserWindow(this,mod);
            f1.Show();

        }



        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }




        

    }

}

