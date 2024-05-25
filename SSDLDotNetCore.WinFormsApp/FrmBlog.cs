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

        public FrmBlog()
        {
            // Must put other codes under InitializeComponent();
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);            
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
                if(result > 0)
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
    }
}
