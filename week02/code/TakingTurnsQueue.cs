
/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is returned and placed back at the back of the queue if they still
/// have turns remaining. A turns value of 0 or less means infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// People with remaining finite turns are added back to the queue.
    /// People with 0 or negative turns have infinite turns and are
    /// always added back without changing their turns value.
    /// An exception is thrown if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns: add the person back without changing their turns.
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Finite turns: reduce the remaining turns and add them back.
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
