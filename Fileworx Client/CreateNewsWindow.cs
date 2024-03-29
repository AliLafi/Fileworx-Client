﻿using FileworxObjects;
using FileworxObjects.DTOs;
using System;
using System.Windows.Forms;

namespace Fileworx_Client
{
    public partial class CreateNewsWindow : Form
    {
        readonly MainWindow main;
        readonly NewsDTO newsItem;
        readonly ApiRequests req = new ApiRequests();
        bool categoryChanged = false;

        public enum Categories
        {
            General,
            Politics,
            Sports,
            Health

        }

        public CreateNewsWindow(MainWindow main, NewsDTO newsFromMain = null)
        {
            InitializeComponent();

            foreach (Categories category in Enum.GetValues(typeof(Categories)))
            {
                listCategory.Items.Add(category.ToString());
            }

            this.main = main;

            if (!(newsFromMain is null))
            {
                newsItem = newsFromMain;
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

        private bool HasChanged()
        {
            if (txtTitle.Modified || txtBody.Modified || categoryChanged || txtDescription.Modified)
            {
                return true;
            }
            return false;
        }

        private bool IsEmpty()
        {
            if (txtTitle.Text == string.Empty || listCategory.Text == string.Empty || txtBody.Text == string.Empty || txtDescription.Text == string.Empty)
            {
                return true;
            }
            return false;
        }

        private void ListCategory_TextChanged(object sender, EventArgs e)
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
            if (newsItem is null)
            {
                NewsDTO temp = new NewsDTO(listCategory.Text,0,txtBody.Text,main.modifier,main.modifier,txtTitle.Text,txtDescription.Text,DateTime.Now,DateTime.Now);
                await req.Create("News", temp);
            }
            else
            {
                AddProperties();
                newsItem.LastModifier= main.modifier;
                newsItem.ModifyDate = DateTime.Now;
                await req.Update("News", newsItem);
            }
            main.UpdateTable();
        }

        private void AddProperties()
        {
            newsItem.Name = txtTitle.Text;
            newsItem.Description = txtDescription.Text;
            newsItem.Body = txtBody.Text;
            newsItem.Category = listCategory.Text;
        }

        private void BtnSave_Click(object sender, EventArgs e)
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

        private void BtnCancel_Click(object sender, EventArgs e)
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
                            main.UpdateTable();
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

        private void CreateNewsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasChanged() && Visible == true)
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
