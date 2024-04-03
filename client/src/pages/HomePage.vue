<template>
  <div class="container-fluid hero-section  d-flex align-items-center justify-content-center">
    <section class="row">
      <div class="col-12">
        <h1 class="hero-title">dig in!</h1>
      </div>
    </section>
  </div>

  <div v-if="account.id" class="container mt-5 position-relative">
    <section class="row justify-content-center">
      <div class="col-6 d-flex justify-content-between nav-banner shadow rounded-3 p-4">
        <h3 role="button" @click="drawAllRecipes()">Home</h3>
        <h3 role="button" @click="drawFavoriteRecipes()">Favorites</h3>
        <h3 role="button" @click="drawUsersRecipes()">My Recipes</h3>
      </div>
    </section>
  </div>


  <div class="container mt-5">
    <section v-if="recipes" class="row m-auto">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4 d-flex justify-content-center mb-2">
        <RecipeCard :recipe="recipe" />
      </div>
    </section>
  </div>

  <div class="create-button-position m-5">
    <div role="button" class="create-button-style d-flex justify-content-center align-items-center"
      data-bs-toggle="modal" data-bs-target="#createRecipeFormModal">
      <p class="pb-2 text-center mb-2">+</p>
    </div>
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
import App from '../App.vue';



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
      account: computed(() => AppState.account),
      recipes: computed(() => AppState.recipes),
      accountFavorites: computed(() => AppState.allAccountFavorites),

      drawFavoriteRecipes() {
        recipesService.drawFavoriteRecipes()
      },
      async drawUsersRecipes() {
        await recipesService.drawUsersRecipes()
      },
      async drawAllRecipes() {
        await recipesService.drawAllRecipes()
      }


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

.nav-banner {
  background-color: white;
  font-family: "Playfair Display", serif;
  font-size: 70px;
  position: absolute;
  bottom: 5px;
}

.create-button-position {
  position: fixed;
  bottom: 0px;
  right: 0px;
}

.create-button-style {
  background-color: #0cbc87;
  border-radius: 50%;
  aspect-ratio: 1/1;
  height: 8vh;
  color: white;
  font-weight: bolder;
  font-size: 10vh;
}
</style>
