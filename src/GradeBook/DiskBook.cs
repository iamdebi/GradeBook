namespace GradeBook
{
    internal class DiskBook : Book
    {

        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            throw new System.NotImplementedException();
        }
    }
}