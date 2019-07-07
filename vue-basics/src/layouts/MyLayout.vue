<template>
  <q-layout >
            <!-- <router-view /> -->
    <h1 v-if="isShow" id="header">hello world {{name}} {{age}}</h1>
    <h1 v-else> currently false </h1>
    <button @click="showMessage"> say hello </button>
    <input  v-model="message" type="text">
  <div> {{message}}</div>

  <ul>
    <li  v-for="user in users"  :key="user.id">
      {{user.name}}
    </li>
  </ul>
  </q-layout>
</template>

<script>
import { openURL } from 'quasar'

export default {
  data () {
    return {
      name: 'moral',
      age: 24,
      isShow: true,
      message: '',
      users: [
        { name: 'Foo' },
        { name: 'Bar' }
      ]
    }
  },
  methods: {
    openURL,
    showMessage () {
      this.isShow = !this.isShow
      // console.log('hello' + this.age)
    },
    addMessage () {
      console.log('add')
    }
  }
}
</script>

<style>

</style>
