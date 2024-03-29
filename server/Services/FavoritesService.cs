

namespace dig_in.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;
    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal FavoriteProfile CreateFavorite(Favorite favoriteData)
    {
        FavoriteProfile favoriteProfile = _repository.CreateFavorite(favoriteData);
        return favoriteProfile;
    }

    // internal List<Recipe> GetUsersFavoriteRecipes(string userId)
    // {
    //     List<Recipe> usersRecipes = _repository.GetUsersFavoriteRecipes(userId);
    //     return usersRecipes;
    // }
}