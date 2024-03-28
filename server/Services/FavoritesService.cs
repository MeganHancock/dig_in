

namespace dig_in.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;
    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite favorite = _repository.CreateFavorite(favoriteData);
        return favorite;
    }

    // internal List<Recipe> GetUsersFavoriteRecipes(string userId)
    // {
    //     List<Recipe> usersRecipes = _repository.GetUsersFavoriteRecipes(userId);
    //     return usersRecipes;
    // }
}