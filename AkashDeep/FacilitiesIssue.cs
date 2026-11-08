using System;

namespace AkashDeep
{
    /// <summary>
    /// Represents a facilities maintenance or repair issue reported in campus premises.
    /// Demonstrates encapsulation through private fields and public properties.
    /// </summary>
    public class FacilitiesIssue
    {
        // Private fields for strict encapsulation
        private int _issueId;
        private string _location = string.Empty;
        private string _category = string.Empty;
        private string _description = string.Empty;
        private DateTime _dateReported = DateTime.Today;
        private string _priority = string.Empty;
        private string _status = string.Empty;
        private string _reportedBy = string.Empty;

        // Public properties providing controlled access
        public int IssueId
        {
            get => _issueId;
            set => _issueId = value;
        }

        public string Location
        {
            get => _location;
            set => _location = value?.Trim() ?? string.Empty;
        }

        public string Category
        {
            get => _category;
            set => _category = value?.Trim() ?? string.Empty;
        }

        public string Description
        {
            get => _description;
            set => _description = value?.Trim() ?? string.Empty;
        }

        public DateTime DateReported
        {
            get => _dateReported;
            set => _dateReported = value;
        }

        public string Priority
        {
            get => _priority;
            set => _priority = value?.Trim() ?? string.Empty;
        }

        public string Status
        {
            get => _status;
            set => _status = value?.Trim() ?? string.Empty;
        }

        public string ReportedBy
        {
            get => _reportedBy;
            set => _reportedBy = value?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FacilitiesIssue()
        {
            _dateReported = DateTime.Today;
            _status = "Open";
            _priority = "Medium";
        }

        /// <summary>
        /// Parameterized constructor for creating a new issue (without ID).
        /// </summary>
        public FacilitiesIssue(string location, string category, string description, DateTime dateReported, string priority, string status, string reportedBy)
        {
            Location = location;
            Category = category;
            Description = description;
            DateReported = dateReported;
            Priority = priority;
            Status = status;
            ReportedBy = reportedBy;
        }

        /// <summary>
        /// Parameterized constructor for existing issues (with ID).
        /// </summary>
        public FacilitiesIssue(int issueId, string location, string category, string description, DateTime dateReported, string priority, string status, string reportedBy)
            : this(location, category, description, dateReported, priority, status, reportedBy)
        {
            _issueId = issueId;
        }

        /// <summary>
        /// Validates business rules for the facilities issue record.
        /// Enforces at least three required business rules before database operations.
        /// </summary>
        /// <param name="errorMessage">Out parameter describing any validation failure.</param>
        /// <returns>True if all validation rules pass; otherwise false.</returns>
        public bool Validate(out string errorMessage)
        {
            // Rule 1: Location must not be empty or whitespace
            if (string.IsNullOrWhiteSpace(_location))
            {
                errorMessage = "Location is required. Please enter the classroom, office, or area (e.g., Room B204).";
                return false;
            }

            // Rule 2: Issue category must be selected
            if (string.IsNullOrWhiteSpace(_category) || _category.Equals("Select Category...", StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = "Please select a valid Issue Category.";
                return false;
            }

            // Rule 3: Description must not be empty and must be at least 5 characters long
            if (string.IsNullOrWhiteSpace(_description))
            {
                errorMessage = "Description is required. Please explain the facilities problem.";
                return false;
            }

            if (_description.Length < 5)
            {
                errorMessage = "Description must be at least 5 characters long to provide sufficient detail.";
                return false;
            }

            // Rule 4: The date reported cannot be in the future
            if (_dateReported.Date > DateTime.Today)
            {
                errorMessage = $"Date Reported ({_dateReported:yyyy-MM-dd}) cannot be in the future. Today is {DateTime.Today:yyyy-MM-dd}.";
                return false;
            }

            // Rule 5: Priority must be selected from Low, Medium, or High
            if (string.IsNullOrWhiteSpace(_priority) ||
                (!_priority.Equals("Low", StringComparison.OrdinalIgnoreCase) &&
                 !_priority.Equals("Medium", StringComparison.OrdinalIgnoreCase) &&
                 !_priority.Equals("High", StringComparison.OrdinalIgnoreCase)))
            {
                errorMessage = "Priority must be selected as Low, Medium, or High.";
                return false;
            }

            // Rule 6: Status must be selected from Open, In Progress, or Resolved
            if (string.IsNullOrWhiteSpace(_status) ||
                (!_status.Equals("Open", StringComparison.OrdinalIgnoreCase) &&
                 !_status.Equals("In Progress", StringComparison.OrdinalIgnoreCase) &&
                 !_status.Equals("Resolved", StringComparison.OrdinalIgnoreCase)))
            {
                errorMessage = "Status must be selected as Open, In Progress, or Resolved.";
                return false;
            }

            // Rule 7: Reported By must not be empty or whitespace
            if (string.IsNullOrWhiteSpace(_reportedBy))
            {
                errorMessage = "Reported By name is required. Please enter the name of the person reporting the issue.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        /// <summary>
        /// Calculates how many days this issue has been active since it was reported.
        /// </summary>
        /// <returns>Number of days elapsed.</returns>
        public int CalculateDaysOpen()
        {
            int days = (DateTime.Today - _dateReported.Date).Days;
            return days < 0 ? 0 : days;
        }

        /// <summary>
        /// Business rule to check if the issue is urgent (High priority and not yet resolved).
        /// </summary>
        /// <returns>True if urgent; otherwise false.</returns>
        public bool IsUrgent()
        {
            return _priority.Equals("High", StringComparison.OrdinalIgnoreCase) &&
                   !_status.Equals("Resolved", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Generates a human-readable summary string for display or logging.
        /// </summary>
        /// <returns>Formatted summary string.</returns>
        public string GetSummary()
        {
            return $"[Issue #{_issueId}] {_category} at {_location} | Priority: {_priority} | Status: {_status} | Reported By: {_reportedBy}";
        }

        public override string ToString()
        {
            return GetSummary();
        }
    }
}

