using System.Collections.Generic;
using System.Linq;

namespace CodeProblems.Problems
{
    public static class LinqProblem1
    {
        public static void Start()
        {
            List<TextingConversation> textingConversations = new List<TextingConversation> {
                new TextingConversation { Id = 1, StudentId = 1 },
                new TextingConversation { Id = 2, StudentId = 2 },
                new TextingConversation { Id = 3, StaffId = 3 },
                new TextingConversation { Id = 4, StaffId = 4 },
                new TextingConversation { Id = 5 }
            };

            List<Student> students = new List<Student> {
                new Student { Id = 1 },
                //new Student { Id = 2 }
            };

            List<Staff> staffs = new List<Staff> {
                new Staff { Id = 3 },
                //new Staff { Id = 4 }
            };

            var result = from tc in textingConversations
                         join student in students
                         on tc.StudentId equals student.Id into tc_students
                         join staff in staffs
                         on tc.StaffId equals staff.Id into tc_staffs
                         from tc_student in tc_students.DefaultIfEmpty()
                         from tc_staff in tc_staffs.DefaultIfEmpty()
                          where
                             (tc.StudentId.HasValue && tc_student != null) ||
                             (tc.StaffId.HasValue && tc_staff != null)
                         select new { tcId = tc.Id, TcStudent = tc_student };

            result = result;

        }

        public class TextingConversation
        {
            public int Id { get; set; }
            public int? StudentId { get; set; }
            public int? StaffId { get; set; }
        }

        public class Student
        {
            public int Id { get; set; }
        }

        public class Staff
        {
            public int Id { get; set; }
        }
    }
}