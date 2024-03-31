<template>
  <div class="container-fluid hero-section mb-5 d-flex align-items-center justify-content-center">
    <section class="row">
      <div class="col-12">
        <h1 class="hero-title">dig in!</h1>
      </div>
    </section>
  </div>

  <!-- <div class="container">
    <section class="row position-absolute top-50">
      <div class="col-6 d-flex justify-content-evenly">
        <div class="hero-navigation">
          <a href="">Home</a>
          <a href="">My Recipes</a>
          <a href="">Favorites</a>
        </div>
      </div>
    </section>
  </div> -->


  <div class="container">
    <section v-if="recipes" class="row m-auto">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4 d-flex justify-content-center mb-2">
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
import { logger } from '../utils/Logger.js';


export default {
  setup() {

    onMounted(() => {
      getRecipes()
    })

    async function getRecipes() {
      try {
        // logger.log('on mounted')
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

<style scoped lang="scss">
.hero-title {
  font-family: "Playfair Display", serif;
  font-optical-sizing: auto;
  font-weight: 800;
  font-style: normal;
  font-size: 100px;
  color: white;
}

.hero-section {
  background-image: url('https://codeworks.blob.core.windows.net/public/assets/img/projects/AllSpicePoster.jpg');
  height: 43vh;
}

.hero-navigation {
  background-color: white;
}
</style>
