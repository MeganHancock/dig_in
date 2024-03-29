

namespace dig_in.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO 
        ingredients(name, quantity, recipeId)
        VALUES(@Name, @Quantity, @RecipeId);

        SELECT
        ingredient.*,
        recipe.* 
        FROM ingredients ingredient
        JOIN recipes recipe ON ingredient.recipeId = recipe.id
        WHERE ingredient.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
        return ingredient;
    }

    internal Ingredient GetIngredientId(int ingredientId)
    {
        string sql = "SELECT * FROM ingredients WHERE id = @ingredientId;";
        Ingredient foundIngredient = _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
        return foundIngredient;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT
        ingredient.*,
        recipe.*
        FROM ingredients ingredient
        JOIN recipes recipe ON ingredient.recipeId = recipe.id 
        WHERE recipe.id = @recipeId
        ;";
        List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
        return ingredients;
    }

    internal void DestroyIngredient(int ingredientId)
    {
        string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
        _db.Execute(sql, new { ingredientId });
    }

}