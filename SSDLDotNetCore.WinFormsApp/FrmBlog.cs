using SSDLDotNetCore.Shared;
using SSDLDotNetCore.WinFormsApp.Model;
using SSDLDotNetCore.WinFormsApp.Queries;
using System.Net.WebSockets;

namespace SSDLDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        // For Color => https://materialui.co/colors

        private readonly DapperService _dapperService;
        private readonly int _blogId;

        public FrmBlog()
        {
            // Must put other codes under InitializeComponent();
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        public FrmBlog(int BlogId)
        {
            InitializeComponent();
            _blogId = BlogId;
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);

            var query = @"Select * from Tbl_Blog Where BlogId = @BlogId";
            var model = _dapperService.QueryFirstOrDefault<BlogModel>(query, new { BlogId = _blogId });

            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogTitle;
            txtContent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel
                {
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };

                int result = _dapperService.Execute(BlogQuery.CreateQuery, blog);
                string message = result > 0 ? "Saving Successful." : "Saving Failed.";
                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
                if (result > 0)
                {
                    ClearControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ClearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogModel
                {
                    BlogId = _blogId,
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };

                var query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                                Where BlogId = @BlogId";

                var result = _dapperService.Execute(query, item);
                var message = result > 0 ? "Updating Successful." : "Updating Failed.";
                MessageBox.Show(message);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
