using FileworxObjects;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fileworx_Client
{
    public partial class ContactListWindow : Form
    {
        MainWindow main;
        ApiRequests apiRequests = new ApiRequests();
        int selectedRow;
        public ContactListWindow(MainWindow main)
        {
            this.main = main;
            InitializeComponent();
            UpdateTable();
        }

        public async void UpdateTable()
        {
            List<ContactDTO> contacts = await apiRequests.GetAll<ContactDTO>("contacts");
            FillTable(contacts);
        }

        private void FillTable(List<ContactDTO> contacts)
        {
            List<GridViewRows> rows = contacts.Select(item => ContactMapper.DtoToGridViewRows(item)).ToList();
            DataTable dataTable = ToDataTable(rows);
            GridView.DataSource = dataTable;
        }

        private DataTable ToDataTable(List<GridViewRows> rows)
        {
            DataTable dataTable = new DataTable(typeof(GridViewRows).Name);
            PropertyInfo[] properties = typeof(GridViewRows).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name);
            }

            foreach (var row in rows)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(row, null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        private async void GridView_CellMouseClickAsync(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedRow = e.RowIndex;
            int id = int.Parse(GridView.Rows[selectedRow].Cells[0].Value.ToString());
            if (selectedRow != -1 && e.Button == MouseButtons.Right)
            {
                DialogResult res = MessageBox.Show($"are you sure you want to delete Contact with id of {id}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    await apiRequests.Delete("Contact", id);
                    UpdateTable();
                }
            }
        }

        private async void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = GridView.CurrentCell.RowIndex;
            int id = int.Parse(GridView.Rows[selectedRow].Cells[0].Value.ToString());
            ContactDTO temp = await apiRequests.GetByID<ContactDTO>("contact", id);
            CreateContactWindow createContactWindow = new CreateContactWindow(main, temp, this);
            createContactWindow.Show();
        }

        private async void CheckRead_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRead.Checked && !checkWrite.Checked)
            {
                List<ContactDTO> receiveContacts = await apiRequests.GetAll<ContactDTO>("contacts/receive");
                FillTable(receiveContacts);
            }
            else
            if (!checkRead.Checked && checkWrite.Checked)
            {
                List<ContactDTO> transmissionContacts = await apiRequests.GetAll<ContactDTO>("contacts/send");
                FillTable(transmissionContacts);
            }
            else
            {
                UpdateTable();
            }
        }
    }
}
