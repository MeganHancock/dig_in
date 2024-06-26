namespace dig_in.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal FavoriteAndRecipe CreateFavorite(Favorite favoriteData)
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

        FavoriteAndRecipe favoriteAndRecipe = _db.Query<Favorite, FavoriteAndRecipe, FavoriteAndRecipe>(sql, (favorite, recipe) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.RecipeId = favorite.RecipeId;
            return recipe;
        },
        favoriteData).FirstOrDefault();
        return favoriteAndRecipe;
    }
    internal Favorite FindFavoriteById(int favoriteId)
    {
        string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";
        Favorite foundFavorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return foundFavorite;
    }
    internal List<FavoriteAndRecipe> GetUsersFavoriteRecipes(string userId)
    {
        string sql = @"
        SELECT 
        favorite.*,
        recipe.*,
        account.*
        FROM favorites favorite
        JOIN recipes recipe ON recipe.id = favorite.recipeId
        JOIN accounts account ON account.id = recipe.creatorId
        WHERE favorite.accountId = @userId;";

        List<FavoriteAndRecipe> usersFavoriteRecipes = _db.Query<Favorite, FavoriteAndRecipe, Account, FavoriteAndRecipe>(sql, (favorite, recipe, account) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.CreatorId = favorite.AccountId;
            recipe.Creator = account;
            return recipe;
        }, new { userId }).ToList();
        return usersFavoriteRecipes;
    }
    internal void DestroyFavorite(int favoriteId)
    {
        string sql = "DELETE FROM favorites WHERE id = @favoriteId;";
        _db.Execute(sql, new { favoriteId });
    }
}
