using System;
using System.Collections.Generic;

namespace Testy1.Models
{
   public class Student : Person
   {
       public int ID { get; set; }
       public string LastName { get; set; }
       public string FirstMidName { get; set; }
       public DateTime EnrollmentDate { get; set; }

       public virtual ICollection<Enrollment> Enrollments { get; set; }
   }
}
