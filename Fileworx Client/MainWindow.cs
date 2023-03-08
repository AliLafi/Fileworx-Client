using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
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

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            DateTime after = DateTime.Parse(afterDate.Text);
            DateTime before = DateTime.Parse(beforeDate.Text);
            List<string> categories = new List<string>();

            foreach (object item in catList.CheckedItems)
            {
                categories.Add(item.ToString());
            }
            
            SearchObject searchObject = new SearchObject(after, before, categories, searchBar.Text);
            searchObject.After= after;
            searchObject.Before= before;
            searchObject.Categories = categories;
            searchObject.Query= searchBar.Text;

            List<NewsDTO> list = (await req.GetSearch<NewsDTO>("News", searchObject));
            List<PhotoDTO> list2 = (await req.GetSearch<PhotoDTO>("Photos", searchObject));
            FillTable(list, list2);
        }

        public async void UpdateTable()
        {
            List<NewsDTO> list = await req.GetAll<NewsDTO>("News");
            List<PhotoDTO> list2 = await req.GetAll<PhotoDTO>("Photos");

            FillTable(list, list2);
        }

        private void FillTable(List<NewsDTO> list, List<PhotoDTO> list2)
        {
            List<GridViewRows> rows = new List<GridViewRows>();
            foreach (NewsDTO item in list)
            {
                rows.Add(NewsMapper.DtoToGridViewRows(item));
            }

            foreach (PhotoDTO item in list2)
            {
                rows.Add(PhotoMapper.DtoToGridViewRows(item));
            }

            DataTable datatTable = ToDataTable(rows);
            GridView.DataSource = datatTable;
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
                int id = int.Parse(GridView.Rows[selectedRow].Cells[0].Value.ToString());
                int classId = int.Parse(GridView.Rows[selectedRow].Cells[4].Value.ToString());

                if (classId == 1)
                {
                    NewsDTO temp = await req.GetByID<NewsDTO>("news", id);
                    txtCategory.Visible = true;
                    txtCategory.Text = temp.Category;
                    lblCategory.Visible = true;
                    txtCreated.Text = temp.Created.ToString();
                    txtTitle.Text = temp.Name;

                }
                else
                {
                    PhotoDTO temp = await req.GetByID<PhotoDTO>("Photos", id);
                    txtCategory.Visible = false;
                    lblCategory.Visible = false;
                    txtCreated.Text = temp.Created.ToString();
                    txtTitle.Text = temp.Name;
                    tabControlMain.TabPages.Add(imageTab);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.ImageLocation = temp.ImagePath;
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

        private async void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = GridView.CurrentCell.RowIndex;

            int id = int.Parse(GridView.Rows[selectedRow].Cells[0].Value.ToString());
            int classId = int.Parse(GridView.Rows[selectedRow].Cells[4].Value.ToString());

            if (classId == 1)
            {
                NewsDTO temp = await req.GetByID<NewsDTO>("News", id);
                CreateNewsWindow f1 = new CreateNewsWindow(this, temp);
                f1.Show();
            }
            else
            {
                PhotoDTO temp = await req.GetByID<PhotoDTO>("Photos", id);
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

        private void BtnReset_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}

