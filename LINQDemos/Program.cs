namespace LINQDemos
{
    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
    class Batch
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public DateTime StartDate { get; set; }
        public int CourseId { get; set; }
    }

        internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>()
           {
             new Course { Id = 1,Name="DotNet", Details="Freshers Course" },
             new Course { Id = 2,Name="Adv DotNet", Details="Inter Course" },
             new Course { Id = 3,Name="Java", Details="Freshers Course" },
             new Course { Id = 4,Name="Adv Java", Details="Freshers Course" }

           };
            List<Batch> batches = new List<Batch>() { 
                new Batch() {BatchId = 1, BatchName ="B001", CourseId=1 , StartDate = DateTime.Parse("12/12/2025")},
                new Batch() {BatchId = 2, BatchName ="B002", CourseId=2 , StartDate = DateTime.Parse("12/12/2025")},
                new Batch() {BatchId = 3, BatchName ="B003", CourseId=4 , StartDate = DateTime.Now},

            };

            // display batch details along with course details
            var batchDetails = (from batch in batches
                                join course in courses
                                 on batch.CourseId equals course.Id
                                select new { batch.BatchId, batch.BatchName, batch.StartDate, course.Id, course.Name, course.Details }).ToList();
            Console.WriteLine("Details are ");
            Console.WriteLine($"Batch ID\tBAtch Name\t STart DAte\tCourse ID\t Course NAme ");
            foreach (var batch in batchDetails)
            {
                Console.WriteLine($"{batch.BatchId}\t{batch.BatchName}\t{batch.StartDate}\t{batch.Id}\t{batch.Name}\t{batch.Details}");

            }
        }
    }
}
