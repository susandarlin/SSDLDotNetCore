using SSDLDotNetCore.Shared;

namespace SSDLDotNetCore.WinFormsAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;
        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string query = $"select * from Tbl_user where email = '{txtEmail.Text.Trim()}' and password = '{txtPassword.Text.Trim()}'";
            string query = $"select * from Tbl_user where email = @Email and password = @Password";
            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim(),
            });
            if(model is null)
            {
                MessageBox.Show("User doesn't exist");
                return;
            }
            MessageBox.Show("Is Admin " + model.Email);
        }
    }

    public class UserModel
    {
        public string Email { get; set; }
        public bool IsAdin { get; set; }
    }
}
