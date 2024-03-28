using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;

namespace dig_in.Services;

public class RecipesService
{
    private readonly RecipesRepository _repository;

    public RecipesService(RecipesRepository repository)
    {
        _repository = repository;
    }
    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }
    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repository.GetAllRecipes();
        return recipes;
    }
    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception($"Invalid ID: {recipeId}");
        }

        return recipe;
    }
    internal string DestroyRecipe(int recipeId, string userId)
    {
        Recipe recipeToDestroy = GetRecipeById(recipeId);

        if (recipeToDestroy.CreatorId != userId)
        {
            throw new Exception("Not Your Recipe");
        }

        _repository.DestroyRecipe(recipeId);

        return $"{recipeToDestroy.Title} has been removed.";
    }


    internal Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeData)
    {
        Recipe recipeToUpdate = GetRecipeById(recipeId);

        if (recipeToUpdate.CreatorId != userId)
        {
            throw new Exception("Not Your Recipe");
        }

        recipeToUpdate.Title = recipeData.Title ?? recipeToUpdate.Title;
        recipeToUpdate.Category = recipeData.Category ?? recipeToUpdate.Category;
        recipeToUpdate.Img = recipeData.Img ?? recipeToUpdate.Img;
        recipeToUpdate.Instructions = recipeData.Instructions ?? recipeToUpdate.Instructions;

        Recipe recipe = _repository.UpdateRecipe(recipeToUpdate);

        return recipe;
    }

}