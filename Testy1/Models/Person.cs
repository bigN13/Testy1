
namespace Testy1.Models
{
   public abstract class Person
   {
      public int PersonID { get; set; }

      public string LastName { get; set; }

      public string FirstMidName { get; set; }

      public string FullName
      {
         get
         {
            return LastName + ", " + FirstMidName;
         }
      }
   }
}
