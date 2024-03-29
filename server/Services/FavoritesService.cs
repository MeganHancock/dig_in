

namespace dig_in.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;
    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal FavoriteAndRecipe CreateFavorite(Favorite favoriteData)
    {
        FavoriteAndRecipe favoriteAndRecipe = _repository.CreateFavorite(favoriteData);
        return favoriteAndRecipe;
    }

    // internal List<Recipe> GetUsersFavoriteRecipes(string userId)
    // {
    //     List<Recipe> usersRecipes = _repository.GetUsersFavoriteRecipes(userId);
    //     return usersRecipes;
    // }
}