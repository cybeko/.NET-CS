namespace Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surame { get; set; }
        public virtual ICollection<Assistant> Assistants { get; set; }
        public virtual ICollection<Curator> Curators { get; set; }
        public virtual ICollection<Dean> Deans { get; set; }
        public virtual ICollection<Head> Heads { get; set; }
    }
    public class Assistant
    {
        public int Id { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
    public class Curator
    {
        public int Id { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
    public class Dean
    {
        public int Id { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
    public class Head
    {
        public int Id { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
    public class Faculty
    {
        public int Id { get; set; }
        public int Building { get; set; }
        public string Name { get; set; }
        public virtual Dean Dean { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public int Building { get; set; }
        public string Name { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Head Head { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }   
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual Department Department { get; set; }

    }
    public class Lecture
    {
        public int Id { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
    public class LectureRoom
    {
        public int Id { get; set; }
        public int Building { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
    public class Schedule
    {
        public int Id { get; set; }
        public int Class { get; set; }
        public int DayOfWeek { get; set; }
        public int Week { get; set; }
        public virtual Lecture Lecture { get; set; }
        public virtual LectureRoom LectureRoom { get; set; }
    }
}
