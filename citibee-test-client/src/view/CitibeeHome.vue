<template>
  <div>
   
  <Menubar :gebruiker='gebruiker'></Menubar>
  <CitibeeMap :lijstParkeergarage='parkeergarages'></CitibeeMap>
  <CustomTabel :velden="itemVelden" ></CustomTabel>
  </div>
</template>

<script>
//voor de vuetabel alles via de state store
import CitibeeMap from '../components/CitibeeMap.vue'
import Menubar from '../components/Menubar.vue'
 
import CustomTabel from '../components/CustomTabel.vue'
import ParkeergarageService from '../services/ParkeergarageService'
    const parkeergarageService = new ParkeergarageService();
export default {
  name: 'CitibeeHome',
  data(){
    return{
        parkeergarages:[],
        gebruiker:{},
        itemVelden:['barcode', 'parkingnr']
    }
  },
  components: {
    CitibeeMap,
    Menubar,
  
    CustomTabel
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
