<template>
  <header class="position-absolute end-0">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer>
  </footer>
  <RecipeModalComponent />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import RecipeModalComponent from './components/RecipeModalComponent.vue';


export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, RecipeModalComponent }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";


:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
