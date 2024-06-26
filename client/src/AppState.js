import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  // @ts-ignore
  account: {},
  
  /** @type {import('./models/Recipe.js').Recipe[]} */
  recipes: [] ,

  /** @type {import('./models/Recipe.js').Recipe[]} */
  usersRecipes: [],

  /** @type {import('./models/Recipe.js').Recipe} */
  activeRecipe: null,
  
  /** @type {import('./models/Ingredient.js').Ingredient[]} */
  activeRecipeIngredients: [],
  
  activeRecipeEditing: false,
  
  /** @type {import('./models/Favorite.js').Favorite[]} */
  allAccountFavorites: [],
  
  /** @type {import('./models/Favorite.js').Favorite[]} */
  activeRecipeAccountFavorites: [],
  
  /** @type {import('./models/Favorite.js').Favorite} */
  activeFavorite: null,

})
