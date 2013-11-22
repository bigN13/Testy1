using System;
using System.Collections.Generic;

namespace Testy1.Models
{
   public class Student : Person
   {
      public DateTime EnrollmentDate { get; set; }

      public virtual ICollection<Enrollment> Enrollments { get; set; }
   }
}
