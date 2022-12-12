
using Application.Commons.Mappings;
using Domain.Entities;

namespace Application.Commons.DTOs
{
    public class PersonDTO : IMapFrom<Person>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
