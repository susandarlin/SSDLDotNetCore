namespace SSDLDotNetCore.WinFormsApp
{
    partial class FrmBlogList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvData = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colContent = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colId, colEdit, colDelete, colTitle, colAuthor, colContent });
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(0, 0);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowTemplate.Height = 25;
            dgvData.Size = new Size(800, 450);
            dgvData.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "BlogId";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            // 
            // colTitle
            // 
            colTitle.DataPropertyName = "BlogTitle";
            colTitle.HeaderText = "Title";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colAuthor
            // 
            colAuthor.DataPropertyName = "BlogAuthor";
            colAuthor.HeaderText = "Author";
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            // 
            // colContent
            // 
            colContent.DataPropertyName = "BlogContent";
            colContent.HeaderText = "Content";
            colContent.Name = "colContent";
            colContent.ReadOnly = true;
            // 
            // FrmBlogList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvData);
            Name = "FrmBlogList";
            Text = "Blogs";
            Load += FrmBlogList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvData;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colContent;
    }
}