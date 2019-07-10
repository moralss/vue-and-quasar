<template>
<div>
  <h1>List of Recipes</h1>
    <Recipe v-for="(recipe , index) in recipes"
     :key="index"
     :recipe="recipe"
     :index="index"
      v-on:remove_event="removeRecipe"
      v-on:edit_event="editRecipe"
     ></Recipe>
      <h1>Add Recipe</h1>
      <Add v-on:add_event="addRecipe"/>
</div>

</template>

<script>
export default {
  name: "Recipes",
  data() {
    return {
      recipes: [
        {
          recipeName: 'Seafood',
          ingredients: 'milk fish'
        },
        {
          recipeName: 'pop',
          ingredients: 'sun flower water'
        }
      ]
    };
  },
  components: {
    Recipe : require('./Recipe').default,
    Add: require('./Add').default
  },
   methods: {
    removeRecipe(index) {
      this.recipes.splice(index , 1);
    },
    addRecipe(item){
      this.recipes.push(item);
    },
    editRecipe(recipe){
    for (var i in this.recipes) {
     if (i == recipe.index) {
        this.recipes[i].recipeName = recipe.recipeName;
        this.recipes[i].ingredients = recipe.ingredients;
        break; 
     }
    }
  }
 }
};
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
