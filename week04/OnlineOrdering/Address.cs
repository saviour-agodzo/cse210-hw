public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public string GetStreet() => _street;
    public string GetCity() => _city;
    public string GetStateOrProvince() => _stateOrProvince;
    public string GetCountry() => _country;

    public void SetStreet(string street) => _street = street;
    public void SetCity(string city) => _city = city;
    public void SetStateOrProvince(string stateOrProvince) => _stateOrProvince = stateOrProvince;
    public void SetCountry(string country) => _country = country;

    public bool IsInUSA()
    {
        return string.Equals(_country, "USA", StringComparison.OrdinalIgnoreCase)
            || string.Equals(_country, "United States", StringComparison.OrdinalIgnoreCase)
            || string.Equals(_country, "United States of America", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}