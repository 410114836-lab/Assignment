using System;
using System.Data;

namespace AkashDeep
{
    public static class VerificationTests
    {
        public static void RunAllTests()
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("RUNNING UNIQUE TASK 3 VERIFICATION TEST SUITE");
            Console.WriteLine("=================================================");

            int testsPassed = 0;
            int totalTests = 0;

            void AssertTest(string testName, bool condition, string detail = "")
            {
                totalTests++;
                if (condition)
                {
                    Console.WriteLine($"[PASS] {testName} {detail}");
                    testsPassed++;
                }
                else
                {
                    Console.WriteLine($"[FAIL] {testName} {detail}");
                    throw new Exception($"Test assertion failed: {testName} - {detail}");
                }
            }

            // Group 1: OOP & Validation Rules in FacilitiesIssue
            Console.WriteLine("\n--- Group 1: OOP & Validation Rules in FacilitiesIssue ---");
            var issue = new FacilitiesIssue();
            AssertTest("Default Constructor Initialized", issue.Status == "Open" && issue.Priority == "Medium");

            issue.Location = "   Level 4 Postgraduate Lounge   ";
            AssertTest("Location Property Encapsulation Trim", issue.Location == "Level 4 Postgraduate Lounge");

            // Rule 1: Empty Location
            var badIssue1 = new FacilitiesIssue("", "Plumbing", "Sink tap leaking", DateTime.Today, "Medium", "Open", "Marcus Vance");
            bool valid1 = badIssue1.Validate(out string err1);
            AssertTest("Validation Rule 1: Empty Location Rejected", !valid1 && err1.Contains("Location is required"), $"Message: {err1}");

            // Rule 2: Empty Category
            var badIssue2 = new FacilitiesIssue("Robotics Mechatronics Lab R-108", "", "Power trip on circuit bench 3", DateTime.Today, "Medium", "Open", "Gurdeep Singh");
            bool valid2 = badIssue2.Validate(out string err2);
            AssertTest("Validation Rule 2: Empty Category Rejected", !valid2 && err2.Contains("Category"), $"Message: {err2}");

            // Rule 3: Short Description (<5 chars)
            var badIssue3 = new FacilitiesIssue("Sir Paul Reeves WG-305", "Lighting", "Bad", DateTime.Today, "Medium", "Open", "Kavita Sharma");
            bool valid3 = badIssue3.Validate(out string err3);
            AssertTest("Validation Rule 3: Short Description (<5 chars) Rejected", !valid3 && err3.Contains("at least 5 characters"), $"Message: {err3}");

            // Rule 4: Future Date Reported
            var badIssue4 = new FacilitiesIssue("Health Sciences Clinic H-110", "Electrical", "Safety power duct damaged", DateTime.Today.AddDays(2), "High", "Open", "Elena Rostova");
            bool valid4 = badIssue4.Validate(out string err4);
            AssertTest("Validation Rule 4: Future Date Reported Rejected", !valid4 && err4.Contains("future"), $"Message: {err4}");

            // Rule 5: Non-standard Priority
            var badIssue5 = new FacilitiesIssue("West Pavilion W-202", "Furniture", "Broken ergonomic task chair", DateTime.Today, "CriticalDanger", "Open", "Liam O'Connor");
            bool valid5 = badIssue5.Validate(out string err5);
            AssertTest("Validation Rule 5: Non-standard Priority Rejected", !valid5 && err5.Contains("Low, Medium, or High"), $"Message: {err5}");

            // Rule 6: Non-standard Status
            var badIssue6 = new FacilitiesIssue("Design Workshop DW-08", "General Maintenance", "Overhead dust extractor loose", DateTime.Today, "Medium", "Archived", "Tariq Mansoor");
            bool valid6 = badIssue6.Validate(out string err6);
            AssertTest("Validation Rule 6: Non-standard Status Rejected", !valid6 && err6.Contains("Open, In Progress, or Resolved"), $"Message: {err6}");

            // Rule 7: Empty ReportedBy
            var badIssue7 = new FacilitiesIssue("Library Quiet Study Q-14", "Heating/Cooling", "AC airflow vent rattling loudly", DateTime.Today, "Low", "Open", "   ");
            bool valid7 = badIssue7.Validate(out string err7);
            AssertTest("Validation Rule 7: Empty ReportedBy Rejected", !valid7 && err7.Contains("Reported By name is required"), $"Message: {err7}");

            // Valid Issue
            var goodIssue = new FacilitiesIssue("Robotics Mechatronics Lab R-108", "Electrical", "Emergency power shutoff cover cracked exposing wiring", DateTime.Today, "High", "Open", "Gurdeep Singh");
            bool validGood = goodIssue.Validate(out string goodErr);
            AssertTest("Valid FacilitiesIssue Passes Validation", validGood && string.IsNullOrEmpty(goodErr));

            // Group 2: Database Operations & Class Interaction via IssueManager
            Console.WriteLine("\n--- Group 2: Database Integration & CRUD via IssueManager ---");
            var manager = new IssueManager();
            AssertTest("IssueManager Instantiated and Connected to LocalDB", !string.IsNullOrEmpty(manager.ConnectionString));

            // Create (Insert)
            var newIssue = new FacilitiesIssue(
                "Robotics Mechatronics Lab R-108",
                "Electrical",
                "Emergency power shutoff cover cracked exposing wiring",
                DateTime.Today,
                "High",
                "Open",
                "Gurdeep Singh"
            );
            bool added = manager.AddIssue(newIssue, out string addErr);
            AssertTest("Create Operation (AddIssue)", added && newIssue.IssueId > 0, $"New Issue ID: #{newIssue.IssueId}");

            // Read (Select)
            DataTable allIssues = manager.GetAllIssues();
            AssertTest("Read Operation (GetAllIssues)", allIssues.Rows.Count >= 1, $"Found {allIssues.Rows.Count} record(s).");

            // Update
            newIssue.Status = "In Progress";
            newIssue.Priority = "High";
            newIssue.Description = "Emergency power shutoff cover cracked - campus electrician dispatched";
            bool updated = manager.UpdateIssue(newIssue, out string updateErr);
            AssertTest("Update Operation (UpdateIssue)", updated, $"Updated ID: #{newIssue.IssueId}");

            // Search & Filter
            Console.WriteLine("\n--- Group 3: Search and Filter Functionality ---");
            DataTable searchRes = manager.SearchAndFilterIssues("Robotics", "All", "All", "All");
            AssertTest("Keyword Search for 'Robotics'", searchRes.Rows.Count >= 1);

            DataTable filterStatusRes = manager.SearchAndFilterIssues("", "All", "In Progress", "All");
            AssertTest("Filter by Status 'In Progress'", filterStatusRes.Rows.Count >= 1);

            // Delete
            Console.WriteLine("\n--- Group 4: Delete Operation ---");
            bool deleted = manager.DeleteIssue(newIssue.IssueId, out string delErr);
            AssertTest("Delete Operation (DeleteIssue)", deleted, $"Deleted ID: #{newIssue.IssueId}");

            Console.WriteLine("\n=================================================");
            Console.WriteLine($"ALL {testsPassed}/{totalTests} UNIQUE VERIFICATION TESTS PASSED SUCCESSFULLY!");
            Console.WriteLine("=================================================");
        }
    }
}
