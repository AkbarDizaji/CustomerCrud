using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person : BaseAuditableEntity
    {
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public Person addFirstName(string firstName)
        {
            this.FirstName = firstName;
            return this;
        }
         public Person addLastName(string lastName)
        {
            this.LastName = lastName;
            return this;
        }
        public Person(string firstName,string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public Person()
        {

        }
    }
}
