namespace ValueObjectDemo;

public record PersonFullNameAsRecordValueObject(string FirstName, string LastName) 
    : RecordValueObject;
