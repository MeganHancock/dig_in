
namespace dig_in.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repository;

    public IngredientsService(IngredientsRepository repository)
    {
        _repository = repository;
    }
    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _repository.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient foundIngredient = _repository.GetIngredientId(ingredientId);

        if (foundIngredient == null)
        {
            throw new Exception($"Invalid ID: {ingredientId}");
        }
        return foundIngredient;
    }

    internal string DestroyIngredient(int ingredientId)
    {
        Ingredient foundIngredient = GetIngredientById(ingredientId);


        _repository.DestroyIngredient(ingredientId);
        return "Ingredient has been removed.";
    }

}