<template>
  <q-page padding>
    <h2 class="text-weight-thin" style="text-align:center">Your list of Todos</h2>
      <div class="q-pa-md" style="max-width: 1000px"
      v-for="(todo , index) in todos"
      :key="index"
      @click="todo.isCompeleted = !todo.isCompeleted"
      :class="todo.isCompeleted ? 'bg-orange-1' : 'bg-green-1'"
      >
    <q-item clickable v-ripple>
        <q-item-section avatar>
          <q-icon color="primary" />
            </q-item-section>
            <q-item-section>{{todo.name}}</q-item-section>
            <q-item-section>{{todo.dueTime}}</q-item-section>
            <q-item-section>{{todo.dueDate}}</q-item-section>
            <q-item-section >
            <!-- <q-checkbox v-model="todo.isCompleted"> -->
            <q-checkbox left-label v-model="todo.isCompeleted"  />
                  </q-item-section>
            <q-item-section side left>
              <q-btn @click="removeTodo(todo.index)"
               round color="black"
                icon="delete" />
            </q-item-section>
      </q-item>
      </div>
  </q-page>
</template>

<script>
export default {
  name: 'PageIndex',
  data () {
    return {
      todos: [
        {
          name: 'go shopping',
          dueDate: '2019/06/01',
          dueTime: '18:30',
          isCompeleted: false
        },
        {
          name: 'practicing typing',
          dueDate: '2019/06/07',
          dueTime: '15:30',
          isCompeleted: false
        },
        {
          name: 'feed my dog',
          dueDate: '2019/07/01',
          dueTime: '14:30',
          isCompeleted: false
        },
        {
          name: 'feed my dog',
          dueDate: '2019/07/01',
          dueTime: '14:30',
          isCompeleted: false
        },
        {
          name: 'go shopping',
          dueDate: '2019/06/01',
          dueTime: '18:30',
          isCompeleted: false
        },
        {
          name: 'practicing typing',
          dueDate: '2019/06/07',
          dueTime: '15:30',
          isCompeleted: false
        },
        {
          name: 'feed my dog',
          dueDate: '2019/07/01',
          dueTime: '14:30',
          isCompeleted: false
        },
        {
          name: 'feed my dog',
          dueDate: '2019/07/01',
          dueTime: '14:30',
          isCompeleted: false
        }
      ]
    }
  },
  components: {
    // 'Todo': require('./Todo').default
  },
  methods: {
    changeBackground (todo) {
      console.log('hello' + todo)
      // todo.isCompeleted = !todo.isCompeleted
    },
    removeTodo (index) {
      console.log('working')
      this.todos.splice(index, 1)
    }
  }
}
</script>
<style>
  #container{
    /* background: blueviolet; */
  }
.bg-orange-1{
  text-decoration: line-through;
}
</style>
