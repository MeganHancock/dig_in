



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
    internal List<FavoriteAndRecipe> GetUsersFavoriteRecipes(string userId)
    {
        List<FavoriteAndRecipe> usersFavoriteRecipes = _repository.GetUsersFavoriteRecipes(userId);
        return usersFavoriteRecipes;
    }

    internal Favorite FindFavoriteById(int favoriteId)
    {
        Favorite foundFavorite = _repository.FindFavoriteById(favoriteId);
        if (foundFavorite == null)
        {
            throw new Exception($"Invalid ID: {favoriteId}");
        }
        return foundFavorite;
    }

    internal string DestroyFavorite(string userId, int favoriteId)
    {
        Favorite foundFavorite = FindFavoriteById(favoriteId);

        if (userId != foundFavorite.AccountId)
        {
            throw new Exception("Get your own favorite");
        }

        _repository.DestroyFavorite(favoriteId);

        return "Recipe has been deleted.";

    }

}