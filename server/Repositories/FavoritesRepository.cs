

namespace dig_in.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO
        favorites(recipeId, accountId)
        VALUES(@RecipeId, @AccountId);

        SELECT 
        favorite.*,
        recipe.*
        FROM favorites favorite
        JOIN recipes recipe ON favorite.recipeId = recipe.id
        WHERE favorite.id = LAST_INSERT_ID();";

        Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();
        return favorite;
    }

    // internal List<Recipe> GetUsersFavoriteRecipes(string userId)
    // {
    //     string sql = @"
    //     SELECT
    //     favorite.*
    //     ;";
    // }
}