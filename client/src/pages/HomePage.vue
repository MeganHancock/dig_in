<template>
  <div class="container">
    <section class="row">

    </section>
  </div>
</template>

<script>
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from "../services/RecipesService.js"


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

    }
  }
}
</script>

<style scoped lang="scss"></style>
