namespace dig_in.Controllers;

public class FavoritesController
{
    private readonly FavoritesService _favoritesService;
    public FavoritesController(FavoritesService favoritesService)
    {
        _favoritesService = favoritesService;
    }
}