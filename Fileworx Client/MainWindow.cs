using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using FileworxObjects;

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

            foreach (Categories category in Enum.GetValues(typeof(Categories)))
            {
                txtCategory.Items.Add(category.ToString());
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

            SearchObject searchObject = new SearchObject(after, before, categories, searchBar.Text)
            {
                After = after,
                Before = before,
                Categories = categories,
                Query = searchBar.Text
            };

            List<NewsDTO> newsList = (await req.GetSearch<NewsDTO>("News", searchObject));
            List<PhotoDTO> PhotoList = (await req.GetSearch<PhotoDTO>("Photos", searchObject));
            FillTable(newsList, PhotoList);
        }

        public async void UpdateTable()
        {
            List<NewsDTO> newsList = await req.GetAll<NewsDTO>("News");
            List<PhotoDTO> photoList = await req.GetAll<PhotoDTO>("Photos");

            FillTable(newsList, photoList);
        }

        private void FillTable(List<NewsDTO> newsList, List<PhotoDTO> photoList)
        {
            List<GridViewRows> rows = (newsList.Select(item => NewsMapper.DtoToGridViewRows(item))).ToList();
            rows.AddRange(photoList.Select(item => PhotoMapper.DtoToGridViewRows(item)));

            DataTable dataTable = ToDataTable(rows);
            GridView.DataSource = dataTable;
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
                    await FillNewsData(id);

                }
                else
                {
                    await FillPhotoData(id);
                }

                if (e.Button == MouseButtons.Right)
                {
                    DialogResult res = MessageBox.Show($"are you sure you want to delete {txtTitle.Text} with id of {id}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        if (classId == 1)
                        {
                            await req.Delete("News", id);
                            UpdateTable();
                        }
                        else
                        {
                            await req.Delete("Photo", id);
                            UpdateTable();
                        }
                    }
                }
            }
        }

        private async Task FillPhotoData(int id)
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

        private async Task FillNewsData(int id)
        {
            NewsDTO temp = await req.GetByID<NewsDTO>("news", id);
            txtCategory.Visible = true;
            txtCategory.Text = temp.Category;
            lblCategory.Visible = true;
            txtCreated.Text = temp.Created.ToString();
            txtTitle.Text = temp.Name;
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

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateContactWindow createContactWindow = new CreateContactWindow(this,null);
            createContactWindow.Show();
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactListWindow listWindow = new ContactListWindow(this);
            listWindow.Show();
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = GridView.CurrentCell.RowIndex;

            int id = int.Parse(GridView.Rows[selectedRow].Cells[0].Value.ToString());
            int classId = int.Parse(GridView.Rows[selectedRow].Cells[4].Value.ToString());

            if (GridView.Columns[e.ColumnIndex].Name == "btnSend")
            {
                TransmissionContactsWindow transmissionContactsWindow = new TransmissionContactsWindow(id,classId);
                transmissionContactsWindow.Show();
            }
        }
    }
}

