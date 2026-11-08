using System;
using System.Data;
using System.Windows.Forms;

namespace AkashDeep
{
    public partial class Form1 : Form
    {
        // Custom manager class handling business logic and database operations
        private IssueManager? _issueManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Instantiate the issue manager (ensures database and table are ready)
                _issueManager = new IssueManager();

                // Set default dropdown values
                if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
                cboPriority.SelectedItem = "Medium";
                cboStatus.SelectedItem = "Open";
                cboFilterStatus.SelectedIndex = 0; // "All"

                // Prevent future date selection in UI
                dtpDateReported.MaxDate = DateTime.Today;
                dtpDateReported.Value = DateTime.Today;

                // Load records into DataGridView
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads all records from the database into the DataGridView.
        /// </summary>
        private void LoadData()
        {
            if (_issueManager == null) return;

            DataTable table = _issueManager.GetAllIssues();
            dgvIssues.DataSource = table;

            // Set user-friendly column header names
            if (dgvIssues.Columns["IssueId"] is DataGridViewColumn colId) colId.HeaderText = "ID";
            if (dgvIssues.Columns["Location"] is DataGridViewColumn colLoc) colLoc.HeaderText = "Location";
            if (dgvIssues.Columns["Category"] is DataGridViewColumn colCat) colCat.HeaderText = "Category";
            if (dgvIssues.Columns["Description"] is DataGridViewColumn colDesc) colDesc.HeaderText = "Description";
            if (dgvIssues.Columns["DateReported"] is DataGridViewColumn colDate)
            {
                colDate.HeaderText = "Date Reported";
                colDate.DefaultCellStyle.Format = "yyyy-MM-dd";
            }
            if (dgvIssues.Columns["Priority"] is DataGridViewColumn colPri) colPri.HeaderText = "Priority";
            if (dgvIssues.Columns["Status"] is DataGridViewColumn colStat) colStat.HeaderText = "Status";
            if (dgvIssues.Columns["ReportedBy"] is DataGridViewColumn colRep) colRep.HeaderText = "Reported By";

            lblRecordCount.Text = "Total Records: " + table.Rows.Count;
            dgvIssues.ClearSelection();
        }

        /// <summary>
        /// Adds a new facilities issue.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_issueManager == null) return;

            // Create a new FacilitiesIssue object with user input
            var issue = new FacilitiesIssue(
                txtLocation.Text,
                cboCategory.Text,
                txtDescription.Text,
                dtpDateReported.Value,
                cboPriority.Text,
                cboStatus.Text,
                txtReportedBy.Text
            );

            // Add issue via manager (manager calls issue.Validate() before DB insert)
            if (_issueManager.AddIssue(issue, out string errorMessage))
            {
                MessageBox.Show("New issue #" + issue.IssueId + " added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Updates the selected facilities issue.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_issueManager == null) return;

            if (!int.TryParse(txtIssueId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Please select an issue from the table to update.", "Select Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create updated issue object
            var issue = new FacilitiesIssue(
                id,
                txtLocation.Text,
                cboCategory.Text,
                txtDescription.Text,
                dtpDateReported.Value,
                cboPriority.Text,
                cboStatus.Text,
                txtReportedBy.Text
            );

            if (_issueManager.UpdateIssue(issue, out string errorMessage))
            {
                MessageBox.Show("Issue #" + id + " updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Deletes the selected facilities issue.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_issueManager == null) return;

            if (!int.TryParse(txtIssueId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Please select an issue from the table to delete.", "Select Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm delete with user
            var result = MessageBox.Show("Are you sure you want to delete Issue #" + id + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (_issueManager.DeleteIssue(id, out string errorMessage))
                {
                    MessageBox.Show("Issue #" + id + " deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Clears all input fields to prepare for a new entry.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtIssueId.Clear();
            txtLocation.Clear();
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            txtDescription.Clear();
            dtpDateReported.Value = DateTime.Today;
            cboPriority.SelectedItem = "Medium";
            cboStatus.SelectedItem = "Open";
            txtReportedBy.Clear();
            dgvIssues.ClearSelection();
            txtLocation.Focus();
        }

        /// <summary>
        /// When a user clicks a row in the DataGridView, populate the textboxes.
        /// </summary>
        private void dgvIssues_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIssues.CurrentRow == null || dgvIssues.CurrentRow.Index < 0) return;

            DataGridViewRow row = dgvIssues.CurrentRow;
            txtIssueId.Text = row.Cells["IssueId"].Value?.ToString() ?? "";
            txtLocation.Text = row.Cells["Location"].Value?.ToString() ?? "";
            cboCategory.Text = row.Cells["Category"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells["DateReported"].Value?.ToString(), out DateTime dt))
            {
                dtpDateReported.Value = dt <= dtpDateReported.MaxDate ? dt : DateTime.Today;
            }

            cboPriority.Text = row.Cells["Priority"].Value?.ToString() ?? "Medium";
            cboStatus.Text = row.Cells["Status"].Value?.ToString() ?? "Open";
            txtReportedBy.Text = row.Cells["ReportedBy"].Value?.ToString() ?? "";
        }

        /// <summary>
        /// Searches and filters records by keyword and status.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_issueManager == null) return;

            string keyword = txtSearch.Text;
            string status = cboFilterStatus.Text;

            DataTable results = _issueManager.SearchAndFilterIssues(keyword, "All", status, "All");
            dgvIssues.DataSource = results;
            lblRecordCount.Text = "Filtered Records: " + results.Rows.Count;
            dgvIssues.ClearSelection();
        }

        /// <summary>
        /// Resets search filters and shows all records.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterStatus.SelectedIndex = 0; // "All"
            LoadData();
        }
    }
}
