<template>
<q-page>
  <!-- <q-list bordered> -->
    <q-item @click="changeBackground()"
    :class="!todo.isCompete ? 'bg-orange-1' : 'bg-red-1'"
     v-ripple>
        <q-item-section avatar>
          <q-icon color="primary" />
        </q-item-section>
           <q-item-section>{{todo.name}}</q-item-section>
            <q-item-section>{{todo.dueTime}}</q-item-section>
            <q-item-section>{{todo.dueDate}}</q-item-section>
            <q-item-section >
            <!-- <q-checkbox v-model="todo.isCompleted"> -->
      <q-checkbox left-label v-model="todo.isCompeted"  />
            </q-item-section>
      </q-item>
      <button  @click="changeBackground(todo)">click </button>
    <!-- </q-list> -->
</q-page>
</template>

<script>
export default {
  name: 'Todo',
  props: ['todo'],
  methods: {
    changeBackground (todo) {
      console.log('hello' + todo)
      todo.isCompeleted = !todo.isCompeleted
    }
  }
}

</script>
<style>
  #container{
    /* background: blueviolet; */
  }
</style>
