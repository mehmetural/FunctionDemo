using FunctionsDemo.Domain;

public static class Extensions
{
    public static EntityBase ValidateTableStorageEntity(this object item)
    {
        return item as EntityBase ?? throw new ArgumentNullException(nameof(item));
    }
}
