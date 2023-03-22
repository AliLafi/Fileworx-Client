using FileworxObjects;
using FileworxObjects.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fileworx_Client
{
    public partial class CreateContactWindow : Form
    {
        MainWindow main;
        ContactListWindow contactList;
        ContactDTO contact;
        ApiRequests apiRequests = new ApiRequests();

        public CreateContactWindow(MainWindow main, ContactDTO contactFromMain = null, ContactListWindow contactList = null)
        {
            InitializeComponent();
            this.main = main;
            if (contactFromMain != null)
            {
                contact = contactFromMain;
                FillText();
            }
            if (contactList != null)
            {
                this.contactList = contactList;
            }
        }

        private void FillText()
        {
            if (contact != null)
            {
                txtDescription.Text = contact.Description;
                txtName.Text = contact.Name;
                checkRead.Checked = contact.IsRead;
                checkWrite.Checked = contact.IsWrite;
                lblRead.Text = contact.ReceivePath;
                lblWrite.Text = contact.SendPath;
                if (checkRead.Checked || checkWrite.Checked)
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void CheckRead_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRead.Checked)
            {
                btnRead.Enabled = true;
            }
            else
            {
                btnRead.Enabled = false;
                lblRead.Text = string.Empty;
                if (!checkWrite.Checked)
                {
                    btnSave.Enabled = false;
                }
            }
        }

        private void CheckWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWrite.Checked)
            {
                btnWrite.Enabled = true;
            }
            else
            {
                btnWrite.Enabled = false;
                lblWrite.Text = string.Empty;
                if (!checkRead.Checked)
                {
                    btnSave.Enabled = false;
                }
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select the Reception path for Contact";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblRead.Text = folderBrowserDialog.SelectedPath;
                btnSave.Enabled = true;
            }

        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select the Transmission path for Contact";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblWrite.Text = folderBrowserDialog.SelectedPath;
                btnSave.Enabled = true;

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!IsEmpty())
            {
                CreateOrUpdate();
                Close();
            }

        }

        private async void CreateOrUpdate()
        {
            if (contact is null)
            {
                ContactDTO contactDTO = new ContactDTO(checkRead.Checked, checkWrite.Checked, lblWrite.Text, lblRead.Text, DateTime.Now, main.modifier, main.modifier, txtName.Text, txtDescription.Text, DateTime.Now, DateTime.Now); ;
                await apiRequests.Create("contact", contactDTO);
            }
            else
            {
                AddProperties();
                contact.LastModifier = main.modifier;
                contact.ModifyDate = DateTime.Now;
                await apiRequests.Update("contact", contact);
                contactList.UpdateTable();
            }
            MessageBox.Show("saved Successfully");

        }

        private void AddProperties()
        {
            contact.Name = txtName.Text;
            contact.Description = txtDescription.Text;
            contact.IsRead = checkRead.Checked;
            contact.IsWrite = checkWrite.Checked;
            contact.SendPath = lblWrite.Text;
            contact.ReceivePath = lblRead.Text;
        }

        private bool IsEmpty()
        {
            return ((string.IsNullOrEmpty(lblRead.Text) && string.IsNullOrEmpty(lblWrite.Text)) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(txtName.Text));
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
