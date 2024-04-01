<template>

  <!-- Button trigger modal -->


  <!-- Modal -->
  <div v-if="activeRecipe" class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModal"
    aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="recipeModalLabel">{{ activeRecipe.title }}</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <img :src="activeRecipe.img" :alt="activeRecipe.title">
          <div>
            <p>
              {{ activeRecipe.instructions }}
            </p>
            <div v-for="ingredient in activeRecipeIngredients" :key="ingredient.id">
              <p>{{ ingredient.name }} - {{ ingredient.quantity }}</p>
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
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { ingredientsService } from '../services/IngredientsService.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { Modal } from 'bootstrap';


export default {
  setup() {

    return {
      activeRecipe: computed(() => AppState.activeRecipe),
      activeRecipeIngredients: computed(() => AppState.activeRecipeIngredients),
      account: computed(() => AppState.account),


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
      }

    }
  }
}
</script>

<style lang="scss" scoped>
img {
  max-height: 50vh;
  max-width: 100%;
  aspect-ratio: 1/1;
  object-fit: cover;
}
</style>