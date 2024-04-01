<template>

  <div v-if="activeRecipe" class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModal"
    aria-hidden="true">
    <div class="modal-dialog modal-xl w-100">
      <div class="modal-content">
        <!-- <div class="modal-header">
          <h1 class="modal-title fs-5" id="recipeModalLabel">{{ activeRecipe.title }}</h1>
        </div> -->
        <div class="modal-body p-0 d-flex ">

          <img :src="activeRecipe.img" :alt="activeRecipe.title" class="m-0 rounded-start w-50">
          <div class="m-1">
            <div>
              <h4 class="text-center">{{ activeRecipe.title }}</h4>

              <div class="card m-1 p-1">
                <h5>Instructions</h5>
                <p>
                  {{ activeRecipe.instructions }}
                </p>
              </div>

              <div class="card m-1 p-1">
                <h5>Ingredients</h5>
                <ul v-for="ingredient in activeRecipeIngredients" :key="ingredient.id">
                  <li>
                    {{ ingredient.name }} - {{ ingredient.quantity }}
                  </li>
                </ul>
                <form @submit="createIngredient(activeRecipe.id)">
                  <div class="input-group m-1">
                    <input v-model="editableIngredientData.ingredient" type="text" class="form-control"
                      placeholder="Add Ingredient" aria-label="addIngredient" aria-describedby="button-addon2" required>
                  </div>
                  <div class="input-group m-1">
                    <input v-model="editableIngredientData.quantity" type="text" class="form-control"
                      placeholder="Add Quantity" aria-label="Recipient's username" aria-describedby="button-addon2">
                    <button class="btn btn-outline-secondary" type="submit" id="button-addon2" required>+</button>
                  </div>

                </form>

              </div>
            </div>
          </div>

        </div>


        <div class="modal-footer d-flex justify-content-between">
          <div v-if="account.id = activeRecipe.creatorId">
            <button @click="removeRecipe(activeRecipe.id)" class="btn btn-warning" type="button">Delete Recipe</button>
          </div>
          <div>
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary" title="Favorite this recipe"><i
                class="mdi mdi-heart"></i></button>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>


<script>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import { ingredientsService } from '../services/IngredientsService.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { Modal } from 'bootstrap';


export default {
  setup() {
    const editableIngredientData = ref({ ingredient: '', quantity: '' })
    return {
      activeRecipe: computed(() => AppState.activeRecipe),
      activeRecipeIngredients: computed(() => AppState.activeRecipeIngredients),
      account: computed(() => AppState.account),
      editableIngredientData,

      async removeRecipe(recipeId) {
        try {
          const wantsToRemove = await Pop.confirm('Are you sure you would like to delete this recipe?')

          if (!wantsToRemove) {
            return
          }

          await recipesService.removeRecipe(recipeId)
          Pop.success('Recipe has been removed.')
          // Modal.getOrCreateInstance('#recipeModal').hide()

        }
        catch (error) {
          Pop.error(error);
        }
      },

      async createIngredient(recipeId) {
        try {
          const newIngredient = await ingredientsService.createIngredient(editableIngredientData.value, recipeId)
          editableIngredientData.value = { ingredient: '', quantity: '' }
        }
        catch (error) {
          Pop.error(error);
        }
      }

    }
  }
}
</script>

<style lang="scss" scoped>
img {
  // max-height: 50vh;
  // max-width: 100;
  aspect-ratio: 1/1.4;
  object-fit: cover;
}
</style>