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

  <div class="create-button-position m-5">
    <button class="create-button-style d-flex justify-content-center align-items-center" data-bs-toggle="modal"
      data-bs-target="#exampleModal">
      <p class="p-0 mb-2">+</p>
    </button>
  </div>


  <CreateRecipeModal />
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from "../services/RecipesService.js"
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import CreateRecipeModal from '../components/CreateRecipeModal.vue';



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
  },
  components: { CreateRecipeModal }
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

.create-button-position {
  position: fixed;
  bottom: 0px;
  right: 0px;
}

.create-button-style {
  background-color: rgb(95, 120, 58);
  border-radius: 50%;
  height: 8vh;
  width: 8vh;
  border-color: rgb(95, 120, 58);
  color: white;
  font-weight: bolder;
  font-size: 50px;
}
</style>
