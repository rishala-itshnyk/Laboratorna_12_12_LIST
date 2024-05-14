namespace Laboratorna_12_12_LIST.Tests;

[TestFixture]
public class Tests
{
 private List<Student> _students;

    [SetUp]
    public void Setup()
    {
        _students = new List<Student>
        {
            new Student { FirstName = "Олена", LastName = "Коваль", Exam1 = 85, Exam2 = 90, Exam3 = 75 },
            new Student { FirstName = "Олександр", LastName = "Усик", Exam1 = 75, Exam2 = 80, Exam3 = 90 },
            new Student { FirstName = "Петро", LastName = "Порошенко", Exam1 = 80, Exam2 = 85, Exam3 = 95 }
        };
    }

    [Test]
    public void SortStudentsByName_StudentsSortedByName()
    {
        var sortedStudents = Program.SortStudentsByName(_students);
        var sortedNames = sortedStudents.Select(s => s.LastName).ToList();
        var expectedNames = new List<string> { "Коваль", "Порошенко", "Усик" };

        CollectionAssert.AreEqual(expectedNames, sortedNames);
    }

    [Test]
    public void SortStudentsByAverageGrade_StudentsSortedByAverageGrade()
    {
        var sortedStudents = Program.SortStudentsByAverageGrade(_students);
        var sortedAverages = sortedStudents.Select(s => (s.Exam1 + s.Exam2 + s.Exam3) / 3).ToList();
        var expectedAverages = new List<int> { 81, 83, 86 };

        CollectionAssert.AreEqual(expectedAverages, sortedAverages);
    }

    [Test]
    public void SortStudentsByExamGrade_StudentsSortedByExamGrade()
    {
        var sortedStudents = Program.SortStudentsByExamGrade(_students, 1);
        var sortedExamGrades = sortedStudents.Select(s => s.Exam1).ToList();
        var expectedExamGrades = new List<int> { 75, 80, 85 };

        CollectionAssert.AreEqual(expectedExamGrades, sortedExamGrades);
    }   
}