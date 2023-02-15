using FileworxObjects;
using System;
using System.Windows.Forms;

namespace Fileworx_Client
{


    public partial class CreatePhotosWindow : Form
    {
        MainWindow main;
        FileOp fileOp = new FileOp();
        Photo photoItem;
        //Photo photo;
        bool imageChange = false;

        public CreatePhotosWindow(MainWindow main, Photo photoFromMain = null)
        {
            InitializeComponent();

            this.main = main;

            if (photoFromMain != null)
            {
                photoItem = photoFromMain;
                FillTxt();
            }

        }

        private void FillTxt()
        {

            txtTitle.Text = photoItem.Title;
            txtDescription.Text = photoItem.Description;
            txtBody.Text = photoItem.Body;
           
            lblImage.Text = photoItem.ImagePath;
            pictureBox.ImageLocation = photoItem.ImagePath;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private bool hasChanged()
        {
            if (txtTitle.Modified || txtBody.Modified || txtDescription.Modified || imageChange)
            {

                return true;

            }

            return false;

        }
        private bool isEmpty()
        {
            if (txtTitle.Text == string.Empty || txtBody.Text == string.Empty || txtDescription.Text == string.Empty)
            {
                return true;
            }
            return false;
        }
        private void openBtn_Click(object sender, EventArgs e)
        {
            this.openFile.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
            "|PNG Portable Network Graphics (*.png)|*.png" +
            "|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
            "|BMP Windows Bitmap (*.bmp)|*.bmp" +
            "|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
            "|GIF Graphics Interchange Format (*.gif)|*.gif";

            this.openFile.Title = "Select Image";

            DialogResult res = this.openFile.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox.ImageLocation = openFile.FileName;
                lblImage.Text = openFile.FileName;
                lblImage.Visible = true;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                imageChange = true;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                if (!isEmpty())
                {
                    if (photoItem == null)
                    {
                        Photo temp = new Photo(txtTitle.Text,DateTime.Now,txtDescription.Text,lblImage.Text,txtBody.Text);
                        temp.Update();
                    }
                    else
                    {
                        photoItem.Title = txtTitle.Text;
                        photoItem.Description = txtDescription.Text;
                        photoItem.Body = txtBody.Text;
                        photoItem.ImagePath = lblImage.Text;
                        photoItem.Update();

                    }
                    main.updateTable();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("A field cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                if (!isEmpty())
                {

                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.Yes:

                            if (photoItem == null)
                            {
                                Photo temp = new Photo(txtTitle.Text, DateTime.Now, txtDescription.Text, lblImage.Text, txtBody.Text);
                                temp.Update();
                            }
                            else
                            {
                                photoItem.Title = txtTitle.Text;
                                photoItem.Description = txtDescription.Text;
                                photoItem.Body = txtBody.Text;
                                photoItem.ImagePath = lblImage.Text;
                                photoItem.Update();

                            }

                            main.updateTable();
                            this.Hide();

                            break;

                        case DialogResult.No:

                            this.Hide();
                            break;

                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Not all fields are filled, do you want to exit without change??", "Fields Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        this.Hide();
                    }

                }

            }
            else
            {
                this.Hide();
            }


        }

        private void CreatePhotosWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasChanged() && this.Visible == true)
            {
                e.Cancel = true;

                if (!isEmpty())
                {

                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {

                        case DialogResult.No:

                            e.Cancel = false;
                            break;

                        case DialogResult.Yes:

                            if (photoItem == null)
                            {
                                Photo temp = new Photo(txtTitle.Text, DateTime.Now, txtDescription.Text, lblImage.Text, txtBody.Text);
                                temp.Update();
                            }
                            else
                            {
                                photoItem.Title = txtTitle.Text;
                                photoItem.Description = txtDescription.Text;
                                photoItem.Body = txtBody.Text;
                                photoItem.ImagePath = lblImage.Text;
                                photoItem.Update();

                            }
                            main.updateTable();
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
                        this.Hide();
                    }

                }

            }

        }

    }

}
