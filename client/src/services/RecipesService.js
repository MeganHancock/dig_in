import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService{

    async getRecipes() {
        // logger.log('recipes service')
        const response = await api.get('api/recipes')
        // logger.log('response data', response.data)
        AppState.recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
        logger.log('mapped recipes', AppState.recipes)
    }
    setActiveRecipe(recipe) {
        AppState.activeRecipe = null
        AppState.activeRecipe = recipe
        // logger.log('active recipe', AppState.activeRecipe)
    }
    
    async createRecipe(recipeData) {
        const response = await api.post('api/recipes', recipeData)
        logger.log(response.data)
        const newRecipe = new Recipe(response.data)
        AppState.recipes.push(newRecipe)
        AppState.activeRecipe = newRecipe
        return newRecipe
    }
    
    async removeRecipe(recipeId) {
        const foundRecipeIndex = AppState.recipes.findIndex((recipe)=> recipe.id == recipeId)
        AppState.recipes.splice(foundRecipeIndex, 1)

    const response = await api.delete(`api/recipes/${recipeId}`)
    AppState.activeRecipe = null
    }

    async getRecipeById(recipeId){
        const response = await api.get(`api/recipes/${recipeId}`)
        logger.log('found recipe by id', response.data)
    }
    setActiveInstructionsEditing(activeRecipeId) {
    AppState.activeRecipeEditing = true
    }

    async saveEditedInstructions(ingredientData, recipeId) {
        const response = await api.put(`api/recipes/${recipeId}`, ingredientData)
        logger.log('updated response', response.data)
        AppState.activeRecipeEditing = false
        AppState.activeRecipe = new Recipe(response.data)
    }
}
export const recipesService = new RecipesService()