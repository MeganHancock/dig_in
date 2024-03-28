namespace dig_in.Repositories;

public class IngredientRepository
{
    private readonly IDbConnection _db;

    public IngredientRepository(IDbConnection db)
    {
        _db = db;
    }
}