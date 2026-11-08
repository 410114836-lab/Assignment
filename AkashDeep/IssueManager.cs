using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace AkashDeep
{
    /// <summary>
    /// Handles database operations and business logic coordination for facilities issues.
    /// Interacts directly with the FacilitiesIssue class.
    /// </summary>
    public class IssueManager
    {
        private readonly string _connectionString;

        public string ConnectionString => _connectionString;

        public IssueManager()
        {
            _connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=CampusFacilitiesDB;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=30;";
            InitializeDatabase();
        }

        /// <summary>
        /// Ensures database and table exist in SQL Server LocalDB.
        /// No dummy/sample data is inserted.
        /// </summary>
        public void InitializeDatabase()
        {
            // 1. Ensure CampusFacilitiesDB exists in LocalDB
            string masterConn = "Server=(LocalDB)\\MSSQLLocalDB;Database=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=30;";
            using (var conn = new SqlConnection(masterConn))
            {
                conn.Open();
                string sql = "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CampusFacilitiesDB') CREATE DATABASE CampusFacilitiesDB;";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // 2. Ensure FacilitiesIssues table exists
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string createTableSql = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FacilitiesIssues')
                    BEGIN
                        CREATE TABLE FacilitiesIssues (
                            IssueId INT IDENTITY(1,1) PRIMARY KEY,
                            Location NVARCHAR(100) NOT NULL,
                            Category NVARCHAR(50) NOT NULL,
                            Description NVARCHAR(500) NOT NULL,
                            DateReported DATETIME NOT NULL,
                            Priority NVARCHAR(20) NOT NULL,
                            Status NVARCHAR(20) NOT NULL,
                            ReportedBy NVARCHAR(100) NOT NULL
                        );
                    END;";
                using (var cmd = new SqlCommand(createTableSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves all facilities issues.
        /// </summary>
        public DataTable GetAllIssues()
        {
            var dataTable = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT IssueId, Location, Category, Description, DateReported, Priority, Status, ReportedBy FROM FacilitiesIssues ORDER BY IssueId DESC;";
                using (var cmd = new SqlCommand(sql, conn))
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Validates and adds a new facilities issue.
        /// </summary>
        public bool AddIssue(FacilitiesIssue issue, out string errorMessage)
        {
            if (issue == null)
            {
                errorMessage = "Issue details cannot be null.";
                return false;
            }

            // Enforce business rules before database operations
            if (!issue.Validate(out errorMessage))
            {
                return false;
            }

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO FacilitiesIssues (Location, Category, Description, DateReported, Priority, Status, ReportedBy)
                        VALUES (@Location, @Category, @Description, @DateReported, @Priority, @Status, @ReportedBy);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Location", issue.Location);
                        cmd.Parameters.AddWithValue("@Category", issue.Category);
                        cmd.Parameters.AddWithValue("@Description", issue.Description);
                        cmd.Parameters.AddWithValue("@DateReported", issue.DateReported.Date);
                        cmd.Parameters.AddWithValue("@Priority", issue.Priority);
                        cmd.Parameters.AddWithValue("@Status", issue.Status);
                        cmd.Parameters.AddWithValue("@ReportedBy", issue.ReportedBy);

                        int newId = Convert.ToInt32(cmd.ExecuteScalar());
                        issue.IssueId = newId;
                    }
                }

                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Database Error: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Validates and updates an existing facilities issue record.
        /// </summary>
        public bool UpdateIssue(FacilitiesIssue issue, out string errorMessage)
        {
            if (issue == null)
            {
                errorMessage = "Issue details cannot be null.";
                return false;
            }

            if (issue.IssueId <= 0)
            {
                errorMessage = "Please select an existing issue from the table to update.";
                return false;
            }

            if (!issue.Validate(out errorMessage))
            {
                return false;
            }

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string sql = @"
                        UPDATE FacilitiesIssues
                        SET Location = @Location,
                            Category = @Category,
                            Description = @Description,
                            DateReported = @DateReported,
                            Priority = @Priority,
                            Status = @Status,
                            ReportedBy = @ReportedBy
                        WHERE IssueId = @IssueId;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IssueId", issue.IssueId);
                        cmd.Parameters.AddWithValue("@Location", issue.Location);
                        cmd.Parameters.AddWithValue("@Category", issue.Category);
                        cmd.Parameters.AddWithValue("@Description", issue.Description);
                        cmd.Parameters.AddWithValue("@DateReported", issue.DateReported.Date);
                        cmd.Parameters.AddWithValue("@Priority", issue.Priority);
                        cmd.Parameters.AddWithValue("@Status", issue.Status);
                        cmd.Parameters.AddWithValue("@ReportedBy", issue.ReportedBy);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            errorMessage = $"No issue found with ID #{issue.IssueId}.";
                            return false;
                        }
                    }
                }

                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Database Error: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Deletes an issue record by ID.
        /// </summary>
        public bool DeleteIssue(int issueId, out string errorMessage)
        {
            if (issueId <= 0)
            {
                errorMessage = "Please select a valid issue record from the table to delete.";
                return false;
            }

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM FacilitiesIssues WHERE IssueId = @IssueId;";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IssueId", issueId);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            errorMessage = $"No issue found with ID #{issueId}.";
                            return false;
                        }
                    }
                }

                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Database Error: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Searches issues by keyword and status.
        /// </summary>
        public DataTable SearchAndFilterIssues(string keyword, string category, string status, string priority)
        {
            var dataTable = new DataTable();
            var sqlBuilder = new StringBuilder("SELECT IssueId, Location, Category, Description, DateReported, Priority, Status, ReportedBy FROM FacilitiesIssues WHERE 1=1");
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sqlBuilder.Append(" AND (Location LIKE @Keyword OR Description LIKE @Keyword OR ReportedBy LIKE @Keyword)");
                parameters.Add(new SqlParameter("@Keyword", $"%{keyword.Trim()}%"));
            }

            if (!string.IsNullOrWhiteSpace(status) && !status.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                sqlBuilder.Append(" AND Status = @Status");
                parameters.Add(new SqlParameter("@Status", status.Trim()));
            }

            sqlBuilder.Append(" ORDER BY IssueId DESC;");

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sqlBuilder.ToString(), conn))
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}
