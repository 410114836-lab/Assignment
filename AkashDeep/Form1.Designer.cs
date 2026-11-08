namespace AkashDeep
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpIssueDetails = new System.Windows.Forms.GroupBox();
            lblIssueId = new System.Windows.Forms.Label();
            txtIssueId = new System.Windows.Forms.TextBox();
            lblLocation = new System.Windows.Forms.Label();
            txtLocation = new System.Windows.Forms.TextBox();
            lblCategory = new System.Windows.Forms.Label();
            cboCategory = new System.Windows.Forms.ComboBox();
            lblDescription = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            lblDateReported = new System.Windows.Forms.Label();
            dtpDateReported = new System.Windows.Forms.DateTimePicker();
            lblPriority = new System.Windows.Forms.Label();
            cboPriority = new System.Windows.Forms.ComboBox();
            lblStatus = new System.Windows.Forms.Label();
            cboStatus = new System.Windows.Forms.ComboBox();
            lblReportedBy = new System.Windows.Forms.Label();
            txtReportedBy = new System.Windows.Forms.TextBox();
            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            grpSearch = new System.Windows.Forms.GroupBox();
            lblSearch = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            lblFilterStatus = new System.Windows.Forms.Label();
            cboFilterStatus = new System.Windows.Forms.ComboBox();
            btnSearch = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            dgvIssues = new System.Windows.Forms.DataGridView();
            lblRecordCount = new System.Windows.Forms.Label();
            grpIssueDetails.SuspendLayout();
            grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIssues).BeginInit();
            SuspendLayout();
            // 
            // grpIssueDetails
            // 
            grpIssueDetails.Controls.Add(btnClear);
            grpIssueDetails.Controls.Add(btnDelete);
            grpIssueDetails.Controls.Add(btnUpdate);
            grpIssueDetails.Controls.Add(btnAdd);
            grpIssueDetails.Controls.Add(txtReportedBy);
            grpIssueDetails.Controls.Add(lblReportedBy);
            grpIssueDetails.Controls.Add(cboStatus);
            grpIssueDetails.Controls.Add(lblStatus);
            grpIssueDetails.Controls.Add(cboPriority);
            grpIssueDetails.Controls.Add(lblPriority);
            grpIssueDetails.Controls.Add(dtpDateReported);
            grpIssueDetails.Controls.Add(lblDateReported);
            grpIssueDetails.Controls.Add(txtDescription);
            grpIssueDetails.Controls.Add(lblDescription);
            grpIssueDetails.Controls.Add(cboCategory);
            grpIssueDetails.Controls.Add(lblCategory);
            grpIssueDetails.Controls.Add(txtLocation);
            grpIssueDetails.Controls.Add(lblLocation);
            grpIssueDetails.Controls.Add(txtIssueId);
            grpIssueDetails.Controls.Add(lblIssueId);
            grpIssueDetails.Location = new System.Drawing.Point(12, 12);
            grpIssueDetails.Name = "grpIssueDetails";
            grpIssueDetails.Size = new System.Drawing.Size(340, 500);
            grpIssueDetails.TabIndex = 0;
            grpIssueDetails.TabStop = false;
            grpIssueDetails.Text = "Issue Details";
            // 
            // lblIssueId
            // 
            lblIssueId.AutoSize = true;
            lblIssueId.Location = new System.Drawing.Point(15, 25);
            lblIssueId.Name = "lblIssueId";
            lblIssueId.Size = new System.Drawing.Size(51, 15);
            lblIssueId.TabIndex = 0;
            lblIssueId.Text = "Issue ID:";
            // 
            // txtIssueId
            // 
            txtIssueId.Location = new System.Drawing.Point(110, 22);
            txtIssueId.Name = "txtIssueId";
            txtIssueId.ReadOnly = true;
            txtIssueId.Size = new System.Drawing.Size(210, 23);
            txtIssueId.TabIndex = 1;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new System.Drawing.Point(15, 60);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new System.Drawing.Size(56, 15);
            lblLocation.TabIndex = 2;
            lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new System.Drawing.Point(110, 57);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new System.Drawing.Size(210, 23);
            txtLocation.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new System.Drawing.Point(15, 95);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new System.Drawing.Size(58, 15);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Category:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Items.AddRange(new object[] { "Lighting", "Furniture", "Heating/Cooling", "Plumbing", "Electrical", "General Maintenance" });
            cboCategory.Location = new System.Drawing.Point(110, 92);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new System.Drawing.Size(210, 23);
            cboCategory.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new System.Drawing.Point(15, 130);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(70, 15);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new System.Drawing.Point(110, 127);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtDescription.Size = new System.Drawing.Size(210, 75);
            txtDescription.TabIndex = 7;
            // 
            // lblDateReported
            // 
            lblDateReported.AutoSize = true;
            lblDateReported.Location = new System.Drawing.Point(15, 215);
            lblDateReported.Name = "lblDateReported";
            lblDateReported.Size = new System.Drawing.Size(85, 15);
            lblDateReported.TabIndex = 8;
            lblDateReported.Text = "Date Reported:";
            // 
            // dtpDateReported
            // 
            dtpDateReported.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDateReported.Location = new System.Drawing.Point(110, 212);
            dtpDateReported.Name = "dtpDateReported";
            dtpDateReported.Size = new System.Drawing.Size(210, 23);
            dtpDateReported.TabIndex = 9;
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new System.Drawing.Point(15, 250);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new System.Drawing.Size(48, 15);
            lblPriority.TabIndex = 10;
            lblPriority.Text = "Priority:";
            // 
            // cboPriority
            // 
            cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPriority.FormattingEnabled = true;
            cboPriority.Items.AddRange(new object[] { "Low", "Medium", "High" });
            cboPriority.Location = new System.Drawing.Point(110, 247);
            cboPriority.Name = "cboPriority";
            cboPriority.Size = new System.Drawing.Size(210, 23);
            cboPriority.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(15, 285);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(42, 15);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Open", "In Progress", "Resolved" });
            cboStatus.Location = new System.Drawing.Point(110, 282);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new System.Drawing.Size(210, 23);
            cboStatus.TabIndex = 13;
            // 
            // lblReportedBy
            // 
            lblReportedBy.AutoSize = true;
            lblReportedBy.Location = new System.Drawing.Point(15, 320);
            lblReportedBy.Name = "lblReportedBy";
            lblReportedBy.Size = new System.Drawing.Size(74, 15);
            lblReportedBy.TabIndex = 14;
            lblReportedBy.Text = "Reported By:";
            // 
            // txtReportedBy
            // 
            txtReportedBy.Location = new System.Drawing.Point(110, 317);
            txtReportedBy.Name = "txtReportedBy";
            txtReportedBy.Size = new System.Drawing.Size(210, 23);
            txtReportedBy.TabIndex = 15;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(15, 370);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(140, 35);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add Issue";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(180, 370);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(140, 35);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update Issue";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(15, 420);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(140, 35);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete Issue";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(180, 420);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(140, 35);
            btnClear.TabIndex = 19;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // grpSearch
            // 
            grpSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpSearch.Controls.Add(btnReset);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(cboFilterStatus);
            grpSearch.Controls.Add(lblFilterStatus);
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Controls.Add(lblSearch);
            grpSearch.Location = new System.Drawing.Point(365, 12);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new System.Drawing.Size(565, 75);
            grpSearch.TabIndex = 1;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search & Filter";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(15, 30);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(45, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(66, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(140, 23);
            txtSearch.TabIndex = 1;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Location = new System.Drawing.Point(215, 30);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new System.Drawing.Size(42, 15);
            lblFilterStatus.TabIndex = 2;
            lblFilterStatus.Text = "Status:";
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "All", "Open", "In Progress", "Resolved" });
            cboFilterStatus.Location = new System.Drawing.Point(263, 27);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new System.Drawing.Size(100, 23);
            cboFilterStatus.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(375, 26);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(80, 25);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new System.Drawing.Point(465, 26);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(80, 25);
            btnReset.TabIndex = 5;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // dgvIssues
            // 
            dgvIssues.AllowUserToAddRows = false;
            dgvIssues.AllowUserToDeleteRows = false;
            dgvIssues.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvIssues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvIssues.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIssues.Location = new System.Drawing.Point(365, 95);
            dgvIssues.MultiSelect = false;
            dgvIssues.Name = "dgvIssues";
            dgvIssues.ReadOnly = true;
            dgvIssues.RowHeadersVisible = false;
            dgvIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvIssues.Size = new System.Drawing.Size(565, 395);
            dgvIssues.TabIndex = 2;
            dgvIssues.CellClick += dgvIssues_CellClick;
            // 
            // lblRecordCount
            // 
            lblRecordCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblRecordCount.AutoSize = true;
            lblRecordCount.Location = new System.Drawing.Point(365, 497);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(103, 15);
            lblRecordCount.TabIndex = 3;
            lblRecordCount.Text = "Total Records: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(944, 526);
            Controls.Add(lblRecordCount);
            Controls.Add(dgvIssues);
            Controls.Add(grpSearch);
            Controls.Add(grpIssueDetails);
            MinimumSize = new System.Drawing.Size(800, 500);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Campus Facilities Issue Register";
            Load += Form1_Load;
            grpIssueDetails.ResumeLayout(false);
            grpIssueDetails.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIssues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpIssueDetails;
        private System.Windows.Forms.Label lblIssueId;
        private System.Windows.Forms.TextBox txtIssueId;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDateReported;
        private System.Windows.Forms.DateTimePicker dtpDateReported;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblReportedBy;
        private System.Windows.Forms.TextBox txtReportedBy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvIssues;
        private System.Windows.Forms.Label lblRecordCount;
    }
}
