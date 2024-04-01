import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class IngredientsService{
createIngredient(ingredientData, recipeId) {
throw new Error('Method not implemented.')
}
async getRecipeIngredientsByRecipeId(recipeId) {
    AppState.activeRecipeIngredients = null
const response = await api.get(`api/recipes/${recipeId}/ingredients`)
AppState.activeRecipeIngredients = response.data.map(ingredientPOJO => new Ingredient(ingredientPOJO))
}

}
export const ingredientsService = new IngredientsService()