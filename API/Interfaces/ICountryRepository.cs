using API.Models;

namespace API.Interfaces;

public interface ICountryRepository
{
    List<Country> GetCountries();
    Country? GetCountry(int id);
    Country? GetCountryByOwner(int ownerId);
    ICollection<Owner> GetOwnersFromACountry(int countryId);
    bool CountryExists(int id);
}