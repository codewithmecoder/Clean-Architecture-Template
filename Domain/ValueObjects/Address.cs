namespace Domain.ValueObjects;

public record Address(string Street, string City, string State, string ZipCode, string Country)
{
    public string Street { get; init; } = Street ?? throw new ArgumentNullException(nameof(Street));
    public string City { get; init; } = City ?? throw new ArgumentNullException(nameof(City));
    public string State { get; init; } = State ?? throw new ArgumentNullException(nameof(State));
    public string ZipCode { get; init; } = ZipCode ?? throw new ArgumentNullException(nameof(ZipCode));
    public string Country { get; init; } = Country ?? throw new ArgumentNullException(nameof(Country));
}