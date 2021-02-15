<template>
<div>
  <loading :active.sync="paginaLaden" 
        :is-full-page="fullPage"></loading>
  <Login v-if="gebruikerId == null" @aanmelden="Aangemeld"></Login>
  <CitibeeHome v-else></CitibeeHome>
  </div>
</template>

<script>

import Login from './view/Login.vue'
import CitibeeHome from './view/CitibeeHome.vue'
import GebruikerService from "./services/GebruikerService"
import ParkeergarageService from "./services/ParkeergarageService"
import { mapState } from 'vuex';
import Vue from "vue"
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';
import AxiosWrapper from "./helpers/AxiosWrapper"
  const axiosWrapper = new AxiosWrapper()
Vue.prototype.$GebruikerService = new GebruikerService(axiosWrapper);
Vue.prototype.$ParkeergarageService = new ParkeergarageService(axiosWrapper);
export default {
  name: 'App',
  data(){
    return{
      gebruikerId:null,
      isLoading: false,
      fullPage: true
    }
  },
  components: {
    Login,
    CitibeeHome,
    Loading
  },
  computed: mapState(['paginaLaden']),
 created(){
   if(this.$store.state.gebruiker!=null){
     this.gebruikerId =this.this.$store.state.gebruiker.id;
   }
 },
 mounted(){
   var me =this
   axiosWrapper.events.on('successResponseResult', function(){
     me.$alertify.success('success');
   });
   axiosWrapper.events.on('errorResponseResult', function(message){
     me.$alertify.error(message);
      })
 },
methods:{
  Aangemeld(value){
    console.log(value)
    this.gebruikerId = value.id
  this.$store.state.gebruiker =value;
  }
}

}
</script>

<style>
 
</style>
