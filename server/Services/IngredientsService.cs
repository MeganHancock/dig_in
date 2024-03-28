namespace dig_in.Services;

public class IngredientsService
{
    private readonly IngredientRepository _repository;

    public IngredientsService(IngredientRepository repository)
    {
        _repository = repository;
    }
}