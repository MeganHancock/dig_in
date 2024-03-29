

namespace dig_in.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal FavoriteProfile CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO
        favorites(recipeId, accountId)
        VALUES(@RecipeId, @AccountId);

        SELECT 
        favorite.*,
        recipe.*
        FROM favorites favorite
        JOIN recipes recipe ON recipe.id = favorite.recipeId
        WHERE favorite.id = LAST_INSERT_ID();";

        FavoriteProfile favoriteProfile = _db.Query<Favorite, FavoriteProfile, FavoriteProfile>(sql, (favorite, recipe) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.RecipeId = favorite.RecipeId;
            return recipe;
        },
        favoriteData).FirstOrDefault();
        return favoriteProfile;
    }

    // internal List<Recipe> GetUsersFavoriteRecipes(string userId)
    // {
    //     string sql = @"
    //     SELECT
    //     favorite.*
    //     ;";
    // }
}