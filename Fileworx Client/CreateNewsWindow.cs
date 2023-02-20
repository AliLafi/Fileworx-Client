using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using FileworxObjects;
using FileworxObjects.DTOs;

namespace Fileworx_Client
{

    public partial class CreateNewsWindow : Form
    {
        MainWindow main;
        NewsDTO newsItem;
        ApiRequests req = new ApiRequests();


        bool categoryChanged = false;
        public enum categories
        {
            General,
            Politics,
            Sports,
            Health

        }

        public CreateNewsWindow(MainWindow main, NewsDTO newsFromMain = null)
        {
            InitializeComponent();

            foreach (categories cat in Enum.GetValues(typeof(categories)))
            {
                listCategory.Items.Add(cat.ToString());

            }

            this.main = main;

            if (newsFromMain != null)
            {
                this.newsItem = newsFromMain;
                FillTxt();
            }


        }


        private void FillTxt()
        {

            txtTitle.Text = newsItem.Name;
            txtDescription.Text = newsItem.Description;
            txtBody.Text = newsItem.Body;
            listCategory.Text = newsItem.Category;

        }



        private bool hasChanged()
        {
            if (txtTitle.Modified || txtBody.Modified || categoryChanged || txtDescription.Modified)
            {

                return true;

            }

            return false;

        }

        private bool isEmpty()
        {
            if (txtTitle.Text == string.Empty || listCategory.Text == string.Empty || txtBody.Text == string.Empty || txtDescription.Text == string.Empty)
            {
                return true;
            }
            return false;

        }

        private void listCategory_TextChanged(object sender, EventArgs e)
        {
            if (newsItem != null)
            {
                if (listCategory.Text != newsItem.Category)
                {
                    categoryChanged = true;

                }
            }


        }

        private async void UpdateOrCreate()
        {
            if (newsItem == null)
            {

                NewsDTO temp = new NewsDTO(txtTitle.Text, txtDescription.Text, DateTime.Now, txtBody.Text, listCategory.Text);
                await req.Create("News", temp);

            }
            else
            {
                newsItem.Name = txtTitle.Text;
                newsItem.Description = txtDescription.Text;
                newsItem.Body = txtBody.Text;
                newsItem.Category = listCategory.Text;
                await req.Update("News", newsItem);

            }
            main.updateTable();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                if (!isEmpty())
                {
                    UpdateOrCreate();
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

                            UpdateOrCreate();
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





        private void CreateNewsWindow_FormClosing(object sender, FormClosingEventArgs e)
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


                            UpdateOrCreate();
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
