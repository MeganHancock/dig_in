namespace dig_in.Controllers;

public class RecipesController
{
    private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService)
    {
        _recipesService = recipesService;
    }
}