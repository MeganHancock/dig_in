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
          <img :src="activeRecipe.imgUrl" :alt="activeRecipe.title">
          <div>
            <p>
              {{ activeRecipe.instructions }}
            </p>
            <div v-for="ingredient in activeRecipeIngredients" :key="ingredient.id">
              <p>{{ ingredient.name }} - {{ ingredient.quantity }}</p>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary" title="Favorite this recipe"><i
              class="mdi mdi-heart"></i></button>
        </div>
      </div>
    </div>
  </div>

</template>


<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';


export default {
  setup() {

    return {
      activeRecipe: computed(() => AppState.activeRecipe),
      activeRecipeIngredients: computed(() => AppState.activeRecipeIngredients),


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