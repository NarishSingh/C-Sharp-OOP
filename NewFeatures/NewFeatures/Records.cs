namespace NewFeatures;

public record Person(string FirstName, string LastName); //positional param record syntax

//inheritance
public abstract record PersonAbstract(string FirstName, string LastName); //positional param record syntax

public record Teacher(string FirstName, string LastName, int Grade)
    : PersonAbstract(FirstName, LastName);

public record Student(string FirstName, string LastName, int CurrentGrade)
    : PersonAbstract(FirstName, LastName);

public record Person2(string FirstName, string LastName, string[] PhoneNums);

public record Employee
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string EmplId { get; init; } = default!;
} //standard prop syntax -> all immutable

#region unused

//can be made mutable, but this is not intended
public record PersonMut
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}

#endregion