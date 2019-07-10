<template>
<div>
  <h1>List of Recipes</h1>
  <li v-for="(recipe , index) in recipes" :key="index">
    <h1>{{recipe.recipeName}}</h1>
  </li>
</div>

</template>

<script>
export default {
  name: "Recipes",
  props: {
    msg: String
  },
  data() {
    return {
      recipes: [
        {
          recipeName: 'Seafood',
          ingredients: ['milk', 'fish']
        },
        {
          recipeName: 'pop',
          ingredients: ['sun flower', 'water']
        }
      ]
    };
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
