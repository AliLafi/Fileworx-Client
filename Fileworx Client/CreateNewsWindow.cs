using System;
using System.Windows.Forms;

namespace Fileworx_Client
{

    public partial class CreateNewsWindow : Form
    {
        MainWindow main;
        FileOp fileOp = new FileOp();
        ListViewItem newsItem;
        News news;
        bool categoryChanged = false;

        // fill categories and check if new or edited 
        public CreateNewsWindow(MainWindow main, ListViewItem newsFromMain = null)
        {
            InitializeComponent();

            foreach (News.categories cat in Enum.GetValues(typeof(News.categories)))
            {
                listCategory.Items.Add(cat.ToString());

            }

            this.main = main;

            if (newsFromMain != null)
            {
                this.newsItem = newsFromMain;
                news = ReconstructNews(newsItem);
                FillTxt();
            }


        }

        // if its not new fill the text boxes
        private void FillTxt()
        {

            txtTitle.Text = news.Title;
            txtDescription.Text = news.Description;
            txtBody.Text = news.Body;
            listCategory.Text = news.Category;

        }

        // reconstruct the object to get values 
        private News ReconstructNews(ListViewItem item)
        {
            News temp = new News(item.SubItems[0].Text, DateTime.Parse(item.SubItems[1].Text), item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text, new Guid(item.SubItems[5].Text));
            return temp;
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
                if (listCategory.Text != newsItem.SubItems[3].Text)
                {
                    categoryChanged = true;

                }
            }


        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                if (!isEmpty())
                {
                    if (newsItem == null)
                    {
                        News temp = new News(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, listCategory.Text, txtBody.Text);
                        fileOp.WriteToFile(temp, temp.guid.ToString());

                    }
                    else
                    {
                        News temp = new News(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, listCategory.Text, txtBody.Text, news.guid);
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

                            if (newsItem == null)
                            {
                                News temp = new News(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, listCategory.Text, txtBody.Text);
                                fileOp.WriteToFile(temp, temp.guid.ToString());
                            }
                            else
                            {
                                News temp = new News(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, listCategory.Text, txtBody.Text, news.guid);
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




        // check for unsaved edits when before closing
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

                            if (newsItem == null)
                            {
                                News temp = new News(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, listCategory.Text, txtBody.Text);
                                fileOp.WriteToFile(temp, temp.guid.ToString());
                            }
                            else
                            {
                                News temp = new News(txtTitle.Text, DateTime.Now.Date, txtDescription.Text, listCategory.Text, txtBody.Text, news.guid);
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
