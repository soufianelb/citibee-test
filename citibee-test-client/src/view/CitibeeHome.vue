<template>
  <div>
  <Sidebar></Sidebar>
  <Menubar :gebruiker='gebruiker'></Menubar>
  <CitibeeMap :lijstParkeergarage='parkeergarages'></CitibeeMap>
  </div>
</template>

<script>
import CitibeeMap from '../components/CitibeeMap.vue'
import Menubar from '../components/Menubar.vue'
import Sidebar from '../components/Sidebar.vue'
import ParkeergarageService from '../services/ParkeergarageService'
    const parkeergarageService = new ParkeergarageService();
export default {
  name: 'CitibeeHome',
  data(){
    return{
        parkeergarages:[],
        gebruiker:{}
    }
  },
  components: {
    CitibeeMap,
    Menubar,
    Sidebar
  },
 created(){
     var me =this;
    parkeergarageService.Parkeergarage().then((data)=>{
        me.parkeergarages = data.data.result
    })
    me.gebruiker = this.$store.state.gebruiker;
 },
methods:{
 
}

}
</script>

<style>
 
</style>
