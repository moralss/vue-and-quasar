<template>
  <div>
    <h1>List of Recipes</h1>
    <Recipe v-for="(recipe , index) in recipes" :key="index" :recipe="recipe" :index="index"></Recipe>
    <h1>Add Recipe</h1>
    <Add />
  </div>
</template>

<script>
import { mapGetters} from "vuex";
export default {
  name: "Recipes",
  computed: {
    ...mapGetters({
      recipes: "getRecipes"
    })
  },
  components: {
    Recipe: require("./Recipe").default,
    Add: require("./Add").default
  }
};
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
