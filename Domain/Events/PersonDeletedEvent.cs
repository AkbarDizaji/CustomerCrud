namespace Domain.Events;

public class PersonDeletedEvent : BaseEvent
{
    public PersonDeletedEvent(Person person)
    {
        Person = person;
    }

    public Person Person { get; }
}
