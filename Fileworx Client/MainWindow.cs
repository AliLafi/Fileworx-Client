using FileworxObjects.DTOs;
using FileworxObjects.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Fileworx_Client
{
    public partial class MainWindow : Form
    {

        int selectedRow;
        readonly ApiRequests req = new ApiRequests();
        public int modifier;

        public enum Categories
        {
            General,
            Politics,
            Sports,
            Health

        }

        public MainWindow()
        {
            InitializeComponent();

            foreach (Categories cat in Enum.GetValues(typeof(Categories)))
            {
                txtCategory.Items.Add(cat.ToString());

            }

        }

        public MainWindow(int modifier)
        {
            InitializeComponent();

            foreach (Categories cat in Enum.GetValues(typeof(Categories)))
            {
                txtCategory.Items.Add(cat.ToString());

            }
            this.modifier = modifier;
            UpdateTable();

        }

        private void SearchBar_Leave(object sender, EventArgs e)
        {
            AddText(sender, e);
        }

        private void SearchBar_MouseClick(object sender, MouseEventArgs e)
        {
            RemoveText(sender, e);

        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (searchBar.Text == "Enter Keyword")
            {
                searchBar.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBar.Text))
                searchBar.Text = "Enter Keyword";
        }

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Parse(startDate.Text);
            DateTime end = DateTime.Parse(endDate.Text);
            List<string> categories = new List<string>();

            RemoveText(sender, e);

            foreach (object item in catList.CheckedItems)
            {
                categories.Add(item.ToString());
            }

            bool valid = true;

            if (start > end)
            {
                MessageBox.Show("The start Date Cannot be after end Date");
                valid = false;
            }

            if (start > DateTime.Now || end > DateTime.Now)
            {
                MessageBox.Show("The Date Cannot be in the future");
                valid = false;
            }

            if (start.Date == DateTime.Now.Date)
            {
                start = DateTime.MinValue;
            }
            if (end.Date == DateTime.Now.Date)
            {
                end = DateTime.MaxValue;
            }

            if (valid)
            {

                SearchObject s = new SearchObject(start, end, categories, searchBar.Text);
                List<NewsDTO> list = (await req.GetSearch<NewsDTO>("News", s));
                List<PhotoDTO> list2 = (await req.GetSearch<PhotoDTO>("Photos", s));
                FillTable(list, list2);
            }
        }

        public async void UpdateTable()
        {
            List<NewsDTO> list = await req.GetAll<NewsDTO>("News");
            List<PhotoDTO> list2 = await req.GetAll<PhotoDTO>("Photos");

            FillTable(list, list2);
        }

        private void FillTable(List<NewsDTO> list, List<PhotoDTO> list2)
        {
            DataTable dt1 = ToDataTable<NewsDTO>(list);
            dt1.Merge(ToDataTable<PhotoDTO>(list2));
            GridView.DataSource = dt1;
            GridView.Columns[0].Visible = false;
            GridView.Columns[6].Visible = false;
            GridView.Columns[7].Visible = false;
            GridView.Columns[1].Visible = false;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {

                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private async void GridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedRow = e.RowIndex;
            tabControlMain.TabPages.Remove(imageTab);

            if (selectedRow != -1)
            {
                txtTitle.Text = GridView.Rows[selectedRow].Cells[3].Value.ToString();
                txtCreated.Text = GridView.Rows[selectedRow].Cells[5].Value.ToString();
                txtBody.Text = GridView.Rows[selectedRow].Cells[1].Value.ToString();
                int id = int.Parse(GridView.Rows[selectedRow].Cells[2].Value.ToString());

                if (string.IsNullOrEmpty(GridView.Rows[selectedRow].Cells[7].Value.ToString()))
                {
                    txtCategory.Visible = true;
                    txtCategory.Text = GridView.Rows[selectedRow].Cells[0].Value.ToString();
                    lblCategory.Visible = true;
                }
                else
                {
                    txtCategory.Visible = false;
                    lblCategory.Visible = false;
                    tabControlMain.TabPages.Add(imageTab);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.ImageLocation = txtCategory.Text = GridView.Rows[selectedRow].Cells[7].Value.ToString();
                }

                if (e.Button == MouseButtons.Right)
                {
                    DialogResult res = MessageBox.Show($"are you sure you want to delete {txtTitle.Text} with id of {id}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(GridView.Rows[selectedRow].Cells[7].Value.ToString()))
                        {
                            await req.Delete("News", id);
                            UpdateTable();
                        }
                        else
                        {
                            await req.Delete("Photo", id);
                        }
                    }
                }
            }
        }

        private void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = GridView.CurrentCell.RowIndex;

            int id = int.Parse(GridView.Rows[selectedRow].Cells[2].Value.ToString());
            string desc = GridView.Rows[selectedRow].Cells[4].Value.ToString();

            if (string.IsNullOrEmpty(GridView.Rows[selectedRow].Cells[7].Value.ToString()))
            {
                NewsDTO temp = new NewsDTO(txtTitle.Text, desc, DateTime.Parse(txtCreated.Text), id, txtBody.Text, txtCategory.Text);
                CreateNewsWindow f1 = new CreateNewsWindow(this, temp);
                f1.Show();

            }
            else
            {
                PhotoDTO temp = new PhotoDTO(txtTitle.Text, desc, DateTime.Parse(txtCreated.Text), id, txtBody.Text, pictureBox.ImageLocation);
                CreatePhotosWindow f1 = new CreatePhotosWindow(this, temp);
                f1.Show();
            }
        }

        private void NewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewsWindow f1 = new CreateNewsWindow(this, null);
            f1.Show();
        }

        private void PhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePhotosWindow f1 = new CreatePhotosWindow(this, null);
            f1.Show();
        }

        private void UserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUserWindow f1 = new CreateUserWindow(this);
            f1.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}

