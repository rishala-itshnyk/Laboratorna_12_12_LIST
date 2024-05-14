using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Exam1 { get; set; }
    public int Exam2 { get; set; }
    public int Exam3 { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.WriteLine("1. Додати студента");
            Console.WriteLine("2. Видалити студента");
            Console.WriteLine("3. Редагувати інформацію про студента");
            Console.WriteLine("4. Сортувати студентів за прізвищем");
            Console.WriteLine("5. Сортувати студентів за середнім балом");
            Console.WriteLine("6. Сортувати студентів за оцінкою з конкретного предмету");
            Console.WriteLine("7. Вихід");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent(students);
                    break;
                case 2:
                    RemoveStudent(students);
                    break;
                case 3:
                    EditStudent(students);
                    break;
                case 4:
                    DisplayStudents(SortStudentsByName(students));
                    break;
                case 5:
                    DisplayStudents(SortStudentsByAverageGrade(students));
                    break;
                case 6:
                    Console.WriteLine("Введіть номер предмету (1, 2 або 3):");
                    int examNumber = int.Parse(Console.ReadLine());
                    DisplayStudents(SortStudentsByExamGrade(students, examNumber));
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    public static void AddStudent(List<Student> students)
    {
        Console.WriteLine("Введіть ім'я студента:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Введіть прізвище студента:");
        string lastName = Console.ReadLine();
        Console.WriteLine("Введіть оцінку з екзамену 1:");
        int exam1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть оцінку з екзамену 2:");
        int exam2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть оцінку з екзамену 3:");
        int exam3 = int.Parse(Console.ReadLine());

        Student newStudent = new Student
        {
            FirstName = firstName,
            LastName = lastName,
            Exam1 = exam1,
            Exam2 = exam2,
            Exam3 = exam3
        };

        students.Add(newStudent);
        Console.WriteLine("Студент доданий успішно.");
    }

    public static void RemoveStudent(List<Student> students)
    {
        Console.WriteLine("Введіть ім'я студента для видалення:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Введіть прізвище студента для видалення:");
        string lastName = Console.ReadLine();

        Student studentToRemove = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            Console.WriteLine("Студент видалений успішно.");
        }
        else
        {
            Console.WriteLine("Студент не знайдений.");
        }
    }

    public static void EditStudent(List<Student> students)
    {
        Console.WriteLine("Введіть ім'я студента для редагування:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Введіть прізвище студента для редагування:");
        string lastName = Console.ReadLine();

        Student studentToEdit = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

        if (studentToEdit != null)
        {
            Console.WriteLine("Введіть нове ім'я студента:");
            string newFirstName = Console.ReadLine();
            Console.WriteLine("Введіть нове прізвище студента:");
            string newLastName = Console.ReadLine();
            Console.WriteLine("Введіть нову оцінку з екзамену 1:");
            int newExam1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть нову оцінку з екзамену 2:");
            int newExam2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть нову оцінку з екзамену 3:");
            int newExam3 = int.Parse(Console.ReadLine());

            studentToEdit.FirstName = newFirstName;
            studentToEdit.LastName = newLastName;
            studentToEdit.Exam1 = newExam1;
            studentToEdit.Exam2 = newExam2;
            studentToEdit.Exam3 = newExam3;

            Console.WriteLine("Інформація про студента відредагована успішно.");
        }
        else
        {
            Console.WriteLine("Студент не знайдений.");
        }
    }

    public static void DisplayStudents(List<Student> students)
    {
        Console.WriteLine("Список студентів:");
        foreach (var student in students)
        {
            Console.WriteLine($"Прізвище: {student.LastName}, Ім'я: {student.FirstName}, " +
                              $"Оцінки: {student.Exam1}, {student.Exam2}, {student.Exam3}");
        }
    }

    public static List<Student> SortStudentsByName(List<Student> students)
    {
        return students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();
    }

    public static List<Student> SortStudentsByAverageGrade(List<Student> students)
    {
        return students.OrderBy(s => (s.Exam1 + s.Exam2 + s.Exam3) / 3).ToList();
    }

    public static List<Student> SortStudentsByExamGrade(List<Student> students, int examNumber)
    {
        switch (examNumber)
        {
            case 1:
                return students.OrderBy(s => s.Exam1).ToList();
            case 2:
                return students.OrderBy(s => s.Exam2).ToList();
            case 3:
                return students.OrderBy(s => s.Exam3).ToList();
            default:
                throw new ArgumentException("Неправильний номер екзамену.");
        }
    }
}
