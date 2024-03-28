namespace dig_in.Controllers;

public class IngredientsController
{
    private readonly IngredientsService _ingredientsService;

    public IngredientsController(IngredientsService ingredientsService)
    {
        _ingredientsService = ingredientsService;
    }
}