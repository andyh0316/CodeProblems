using System.Collections.Generic;
using System.Linq;

namespace CodeProblems.Problems
{
    public static class LinqProblem2
    {
        public static void Start()
        {
            List<Student> students = new List<Student> {
                new Student { Id = 1 },
                new Student { Id = 2 },
                new Student { Id = 3 },
            };

            List<StudentParent> studentParents = new List<StudentParent> {
                new StudentParent { StudentId = 2, ParentId = 2 },
                new StudentParent { StudentId = 2, ParentId = 3 },
                new StudentParent { StudentId = 3, ParentId = 2 },
            };

            List<Parent> parents = new List<Parent> {
                new Parent { Id = 1 },
                new Parent { Id = 2 },
                new Parent { Id = 3 },
            };

            var result1 = from parent in parents
                          join studentParent in studentParents
                          on parent.Id equals studentParent.ParentId
                          //join student in students
                          //on studentParent.StudentId equals student.Id
                          //  from tc_staff in tc_staffs.DefaultIfEmpty()
                          //  where
                          //     (tc.StudentId.HasValue && tc_student != null) ||
                          //     (tc.StaffId.HasValue && tc_staff != null)
                          select new { ParentId = parent.Id };

            result1 = result1;


            var result2 =
                        from parent in parents
                        join studentParent in studentParents
                            on parent.Id equals studentParent.ParentId into parent_studentParents
                        from parent_studentParent in parent_studentParents.DefaultIfEmpty()
                        join student in students
                            on (parent_studentParent != null ? parent_studentParent.StudentId : (int?)null) equals student.Id into studentParent_students 
                        from studentParent_student in studentParent_students.DefaultIfEmpty()
                        //  from tc_staff in tc_staffs.DefaultIfEmpty()
                        //  where
                        //     (tc.StudentId.HasValue && tc_student != null) ||
                        //     (tc.StaffId.HasValue && tc_staff != null)
                        where
                           parent_studentParent != null
                        select new { ParentId = parent.Id };

            result2 = result2;
        }

        public class Student
        {
            public int Id { get; set; }
        }

        public class StudentParent
        {
            public int StudentId { get; set; }
            public int ParentId { get; set; }
        }

        public class Parent
        {
            public int Id { get; set; }
        }
    }
}