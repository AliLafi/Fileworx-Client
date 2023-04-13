using FileworxObjects.DTOs;
using FileworxObjects.Objects;
using FileworxObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using FileworxObjects.Mappers;

namespace Fileworx_Client
{
    public partial class TransmissionContactsWindow : Form
    {
         int fileId;
         int classId;
        ApiRequests apiRequests = new ApiRequests();
        readonly WindowsServiceRequests windowsServiceRequests = new WindowsServiceRequests();

        public TransmissionContactsWindow(int id , int classId)
        {
            InitializeComponent();
            fileId= id;
            this.classId= classId;
            UpdateTable();
        }
        public async void UpdateTable()
        {
            List<ContactDTO> contacts = await apiRequests.GetAll<ContactDTO>("contacts/send");
            FillTable(contacts);
        }

        private void FillTable(List<ContactDTO> contacts)
        {
            List<GridViewRows> rows = contacts.Select(item => ContactMapper.DtoToGridViewRows(item)).ToList();
            DataTable dataTable = ToDataTable(rows);
            gridView.DataSource = dataTable;
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

        private async void GridView_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow =gridView.CurrentCell.RowIndex;
            int id = int.Parse(gridView.Rows[selectedRow].Cells[0].Value.ToString());
            if (gridView.Columns[e.ColumnIndex].Name == "btnSend")
            {
                if(classId == 1)
                {
                    await windowsServiceRequests.TransmitFile("news", fileId, id);
                }
                else
                {
                    await windowsServiceRequests.TransmitFile("photo", fileId, id);
                }
                Close();
                MessageBox.Show("file sent");
            }
        }
    }
}
