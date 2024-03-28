<template>
  <div class="container">
    <section v-if="recipes" class="row m-auto">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4 d-flex justify-content-center mb-5">
        <RecipeCard :recipe="recipe" />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from "../services/RecipesService.js"
import { AppState } from '../AppState.js';


export default {
  setup() {

    onMounted(() => {
      getRecipes()
    })

    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      }
      catch (error) {
        Pop.error(error);
      }
    }

    return {
      recipes: computed(() => AppState.recipes)

    }
  }
}
</script>

<style scoped lang="scss"></style>
