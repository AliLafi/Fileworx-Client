using FileworxObjects.DTOs;
using System;
using System.Windows.Forms;

namespace Fileworx_Client
{


    public partial class CreatePhotosWindow : Form
    {
        readonly PhotoDTO photoItem;
        bool imageChange = false;
        readonly ApiRequests req = new ApiRequests();
        readonly MainWindow mainWindow;


        public CreatePhotosWindow(MainWindow m, PhotoDTO photoFromMain = null)
        {
            InitializeComponent();
            mainWindow = m;

            if (photoFromMain != null)
            {
                photoItem = photoFromMain;
                FillTxt();
            }

        }

        private void FillTxt()
        {

            txtTitle.Text = photoItem.Name;
            txtDescription.Text = photoItem.Description;
            txtBody.Text = photoItem.Body;

            lblImage.Text = photoItem.ImagePath;
            pictureBox.ImageLocation = photoItem.ImagePath;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private bool HasChanged()
        {
            if (txtTitle.Modified || txtBody.Modified || txtDescription.Modified || imageChange)
            {

                return true;

            }

            return false;

        }

        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtBody.Text) || string.IsNullOrEmpty(txtDescription.Text) )
            {
                return true;
            }
            return false;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            this.openFile.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
            "|PNG Portable Network Graphics (*.png)|*.png" +
            "|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
            "|BMP Windows Bitmap (*.bmp)|*.bmp" +
            "|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
            "|GIF Graphics Interchange Format (*.gif)|*.gif";

            openFile.Title = "Select Image";

            DialogResult res = openFile.ShowDialog();

            if (res == DialogResult.OK)
            {
                pictureBox.ImageLocation = openFile.FileName;
                lblImage.Text = openFile.FileName;
                lblImage.Visible = true;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                imageChange = true;
            }

        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                if (!IsEmpty())
                {
                    UpdateOrCreate();
                    Hide();

                }
                else
                {
                    MessageBox.Show("A field cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }

        }

        private void ButtonCancel_ClickAsync(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                if (!IsEmpty())
                {

                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.Yes:

                            UpdateOrCreate();
                            Hide();

                            break;

                        case DialogResult.No:

                            Hide();
                            break;

                    }

                }
                else
                {
                    DialogResult res = MessageBox.Show("Not all fields are filled, do you want to exit without change??", "Fields Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        Hide();
                    }

                }

            }
            else
            {
                Hide();
            }

        }

        private async void UpdateOrCreate()
        {
            if (photoItem == null)
            {
                pictureBox.ImageLocation = (pictureBox.ImageLocation == null) ? "abc" : pictureBox.ImageLocation;
                PhotoDTO temp = new PhotoDTO(txtTitle.Text, txtDescription.Text, DateTime.Now, txtBody.Text, pictureBox.ImageLocation);
                await req.Create("Photo", temp);

            }
            else
            {
                photoItem.Name = txtTitle.Text;
                photoItem.Description = txtDescription.Text;
                photoItem.Body = txtBody.Text;
                photoItem.ImagePath = lblImage.Text;
                await req.Update("Photo", photoItem);

            }

            mainWindow.UpdateTable();

        }

        private void CreatePhotosWindow_FormClosingAsync(object sender, FormClosingEventArgs e)
        {
            if (HasChanged() && this.Visible == true)
            {
                e.Cancel = true;

                if (!IsEmpty())
                {

                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {

                        case DialogResult.No:

                            e.Cancel = false;
                            break;

                        case DialogResult.Yes:

                            UpdateOrCreate();
                            mainWindow.Show();
                            e.Cancel = false;

                            break;

                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;

                    }

                }
                else
                {
                    DialogResult res = MessageBox.Show("Not all fields are filled, do you want to exit without change??", "Fields Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        Hide();
                    }

                }

            }

        }

    }

}
