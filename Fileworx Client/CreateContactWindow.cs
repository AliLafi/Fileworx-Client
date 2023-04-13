using FileworxObjects;
using FileworxObjects.DTOs;
using System;
using System.Windows.Forms;

namespace Fileworx_Client
{
    public partial class CreateContactWindow : Form
    {
        readonly MainWindow main;
        readonly ContactListWindow contactList;
        readonly ContactDTO contact;
        readonly ApiRequests apiRequests = new ApiRequests();

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
                checkReadFile.Checked = contact.IsReadFile;
                checkWriteFile.Checked = contact.IsWriteFile;
                checkReadFtp.Checked = contact.IsReadFtp;
                checkWriteFtp.Checked = contact.IsWriteFtp;
                checkWriteTelegram.Checked = contact.IsWriteTelegram;
                lblRead.Text = contact.ReceiveFilePath;
                lblWrite.Text = contact.SendFilePath;
                txtPassword.Text = contact.Password;
                txtUsername.Text = contact.Username;
                txtHost.Text = contact.Host;
                txtReadFtp.Text = contact.ReceiveFtpPath;
                txtWriteFtp.Text = contact.SendFtpPath;
                txtUsernameTelegram.Text = contact.TelegramUsername;

                if (checkReadFile.Checked || checkWriteFile.Checked || checkReadFtp.Checked || checkWriteFtp.Checked)
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void CheckReadFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkReadFile.Checked)
            {
                btnReadFile.Enabled = true;
            }
            else
            {
                btnReadFile.Enabled = false;
                lblRead.Text = string.Empty;
                CheckBoxes();
            }
        }

        private void CheckWriteFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWriteFile.Checked)
            {
                btnWriteFile.Enabled = true;
            }
            else
            {
                btnWriteFile.Enabled = false;
                lblWrite.Text = string.Empty;
                CheckBoxes();
            }
        }

        private void CheckReadFtp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkReadFtp.Checked)
            {
                txtReadFtp.Enabled = true;
            }
            else
            {
                txtReadFtp.Enabled = false;
            }
            CheckBoxes();
        }

        private void CheckWriteFtp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWriteFtp.Checked)
            {
                txtWriteFtp.Enabled = true;
            }
            else
            {
                txtWriteFtp.Enabled = false;
            }
            CheckBoxes();
        }
        private void CheckWriteTelegram_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWriteTelegram.Checked)
            {
                txtUsernameTelegram.Enabled = true;
            }
            else
            {
                txtUsernameTelegram.Enabled = false;
            }
            CheckBoxes();
        }

        private void CheckBoxes()
        {
            if (!(!string.IsNullOrEmpty(lblWriteFile.Text)|| !string.IsNullOrEmpty(lblReadFile.Text)|| checkWriteFtp.Checked || checkReadFtp.Checked || checkWriteTelegram.Checked))
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
        private void BtnRead_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select the Reception path for Contact";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblReadFile.Text = folderBrowserDialog.SelectedPath;
                btnSave.Enabled = true;
            }

        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select the Transmission path for Contact";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblWriteFile.Text = folderBrowserDialog.SelectedPath;
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
                ContactDTO contactDTO = new ContactDTO(checkReadFile.Checked, checkWriteFile.Checked, lblWrite.Text, lblRead.Text, DateTime.Now,checkWriteFtp.Checked,checkReadFtp.Checked,txtWriteFtp.Text,txtReadFtp.Text,DateTime.Now,txtHost.Text,txtUsername.Text,txtPassword.Text, checkWriteTelegram.Checked, txtUsernameTelegram.Text, main.modifier, main.modifier, txtName.Text, txtDescription.Text, DateTime.Now, DateTime.Now); ;
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
            contact.IsReadFile = checkReadFile.Checked;
            contact.IsWriteFile = checkWriteFile.Checked;
            contact.SendFilePath = lblWrite.Text;
            contact.ReceiveFilePath = lblRead.Text;
            contact.Host= txtHost.Text;
            contact.Username= txtUsername.Text;
            contact.Password= txtPassword.Text;
            contact.SendFtpPath = txtWriteFtp.Text;
            contact.ReceiveFtpPath= txtReadFtp.Text;
            contact.IsReadFtp= checkReadFtp.Checked;
            contact.IsWriteFtp= checkWriteFtp.Checked;
            contact.IsWriteTelegram = checkWriteTelegram.Checked;
            contact.TelegramUsername = txtUsernameTelegram.Text;
        }

        private bool IsEmpty()
        {
            return ((string.IsNullOrEmpty(lblRead.Text) && string.IsNullOrEmpty(lblWrite.Text) && string.IsNullOrEmpty(txtWriteFtp.Text)&&string.IsNullOrEmpty(txtReadFtp.Text) && string.IsNullOrEmpty(txtUsernameTelegram.Text)) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(txtName.Text));
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
