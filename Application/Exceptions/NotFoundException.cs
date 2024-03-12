namespace Application.Exceptions
{
    public class NotFoundException(string name, object key) : ApplicationException($"Entity {name} {key} not found")
    {
    }
}
