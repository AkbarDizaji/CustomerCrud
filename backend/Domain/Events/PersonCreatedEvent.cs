namespace Domain.Events;

public class PersonCreatedEvent : BaseEvent
{
    public PersonCreatedEvent(Person person)
    {
        Person = person;
    }

    public Person Person { get; }
}
