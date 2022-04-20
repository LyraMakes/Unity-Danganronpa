using System;

public class InvalidXmlException : Exception
{
    public InvalidXmlException(string message) : base(message) { }
}
