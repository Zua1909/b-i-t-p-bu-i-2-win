using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Hocsinh
{
    static void Main(string[] args)
    {
        // Cấu hình console để hỗ trợ tiếng Việt
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Tạo danh sách học sinh
        var students = CreateStudentList();

        // A. Xuất danh sách học sinh
        Console.WriteLine("=== Danh sách toàn bộ học sinh ===");
        PrintStudentList(students);

        // B. Tìm học sinh trong độ tuổi từ 15 đến 18
        var studentsInAgeRange = FilterByAgeRange(students, 15, 18);
        Console.WriteLine("\n=== Học sinh có tuổi từ 15 đến 18 ===");
        PrintStudentList(studentsInAgeRange);

        // C. Tìm học sinh có tên chứa chữ 'A'
        var studentsWithAInName = FindStudentsWithCharacterInName(students, 'A');
        Console.WriteLine("\n=== Học sinh có tên chứa chữ 'A' ===");
        PrintStudentList(studentsWithAInName);

        // D. Tính tổng tuổi của tất cả học sinh
        int totalAge = CalculateTotalAge(students);
        Console.WriteLine($"\nTổng tuổi của tất cả học sinh: {totalAge}");

        // E. Tìm học sinh lớn tuổi nhất
        var oldestStudent = FindOldestStudent(students);
        Console.WriteLine("\n=== Học sinh lớn tuổi nhất ===");
        PrintStudent(oldestStudent);

        // F. Sắp xếp danh sách theo tuổi tăng dần
        var sortedStudents = SortByAgeAscending(students);
        Console.WriteLine("\n=== Danh sách học sinh sắp xếp theo tuổi tăng dần ===");
        PrintStudentList(sortedStudents);
    }

    // Hàm tạo danh sách học sinh
    static List<Student> CreateStudentList()
    {
        return new List<Student>
        {
            new Student { Id = 1, Name = "Nguyễn Lê Nhã An", Age = 16 },
            new Student { Id = 2, Name = "Nguyễn Thanh Quý", Age = 18 },
            new Student { Id = 3, Name = "Lương Hoài Phong", Age = 14 },
            new Student { Id = 4, Name = "Lê Đức Toàn", Age = 17 },
            new Student { Id = 5, Name = "Nguyễn Minh Quang", Age = 19 }
        };
    }

    // Hàm hiển thị danh sách học sinh
    static void PrintStudentList(List<Student> students)
    {
        foreach (var student in students)
        {
            PrintStudent(student);
        }
    }

    // Hàm hiển thị thông tin một học sinh
    static void PrintStudent(Student student)
    {
        Console.WriteLine($"ID: {student.Id}, Tên: {student.Name}, Tuổi: {student.Age}");
    }

    // Hàm lọc học sinh theo độ tuổi
    static List<Student> FilterByAgeRange(List<Student> students, int minAge, int maxAge)
    {
        return students.Where(s => s.Age >= minAge && s.Age <= maxAge).ToList();
    }

    // Hàm tìm học sinh có tên chứa ký tự cụ thể
    static List<Student> FindStudentsWithCharacterInName(List<Student> students, char character)
    {
        return students.Where(s => s.Name.Contains(character, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Hàm tính tổng tuổi của học sinh
    static int CalculateTotalAge(List<Student> students)
    {
        return students.Sum(s => s.Age);
    }

    // Hàm tìm học sinh lớn tuổi nhất
    static Student FindOldestStudent(List<Student> students)
    {
        return students.OrderByDescending(s => s.Age).FirstOrDefault();
    }

    // Hàm sắp xếp học sinh theo tuổi tăng dần
    static List<Student> SortByAgeAscending(List<Student> students)
    {
        return students.OrderBy(s => s.Age).ToList();
    }
}
