namespace dig_in.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;
    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

}