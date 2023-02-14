using System;
using System.Windows.Forms;

namespace Fileworx_Client
{


    public partial class CreatePhotosWindow : Form
    {
        MainWindow main;
        FileOp fileOp = new FileOp();
        ListViewItem photoItem;
        Photo photo;
        bool imageChange = false;

        public CreatePhotosWindow(MainWindow main, ListViewItem photoFromMain = null)
        {
            InitializeComponent();

            this.main = main;

            if (photoFromMain != null)
            {
                photoItem = photoFromMain;
                photo = ReconstructPhoto(photoItem);
                FillTxt();
            }

        }

        private void FillTxt()
        {

            txtTitle.Text = photo.Title;
            txtDescription.Text = photo.Description;
            txtBody.Text = photo.Body;
            lblImage.Text = photo.ImagePath;
            pictureBox.ImageLocation = photo.ImagePath;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        private Photo ReconstructPhoto(ListViewItem item)
        {

            Photo temp = new Photo(item.SubItems[0].Text, DateTime.Parse(item.SubItems[1].Text), item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text, new Guid(item.SubItems[5].Text));
            return temp;

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
                        Photo temp = new Photo(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, pictureBox.ImageLocation, txtBody.Text);
                        fileOp.WriteToFile(temp, temp.guid.ToString());
                    }
                    else
                    {
                        Photo temp = new Photo(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, pictureBox.ImageLocation, txtBody.Text, photo.guid);
                        fileOp.WriteToFile(temp, temp.guid.ToString());
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
                                Photo temp = new Photo(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, pictureBox.ImageLocation, txtBody.Text);
                                fileOp.WriteToFile(temp, temp.guid.ToString());
                            }
                            else
                            {
                                Photo temp = new Photo(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, pictureBox.ImageLocation, txtBody.Text, photo.guid);
                                fileOp.WriteToFile(temp, temp.guid.ToString());
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
            if (hasChanged() && this.Visible== true )
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
                                Photo temp = new Photo(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, pictureBox.ImageLocation, txtBody.Text);
                                fileOp.WriteToFile(temp, temp.guid.ToString());
                            }
                            else
                            {
                                Photo temp = new Photo(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, pictureBox.ImageLocation, txtBody.Text, photo.guid);
                                fileOp.WriteToFile(temp, temp.guid.ToString());
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
