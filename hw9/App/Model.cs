namespace Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
    }
    public class Curator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Financing { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    }
    public class Department
    {
        public int Id { get; set; }
        public double Financing { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<GroupsLectures> GroupsLectures { get; set; } = new List<GroupsLectures>();
    }
    public class Lecture
    {
        public int Id { get; set; }
        public string LectureRoom { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<GroupsLectures> GroupsLectures { get; set; } = new List<GroupsLectures>();
    }
    public class GroupsLectures
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int LectureId { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
    public class GroupsCurators
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int CuratorId { get; set; }
        public virtual Curator Curator { get; set; }
    }

}
