<template>
  <div class="map">
    <LMap :zoom="zoom" :center="center">
      <LTileLayer :url="url"></LTileLayer>
      <div v-for="item in lijstParkeergarage" :key="item.id">
      <LMarker @click="SelecteerGarage(item)" :lat-lng="[parseFloat(item.lat),parseFloat(item.lng)]"></LMarker>
    </div>
    </LMap>
  </div>
</template>

<script>
 
import { LMap, LTileLayer, LMarker } from "vue2-leaflet";
import ParkeergarageService from '../services/ParkeergarageService'
    const parkeergarageService = new ParkeergarageService();
export default {
  name: "CitibeeMap",
  components: {
    LMap,
    LTileLayer,
    LMarker
  },
  props: ['lijstParkeergarage'],
  data() {
    return {
      url: "https://{s}.tile.osm.org/{z}/{x}/{y}.png",
      zoom: 10,
      center: [51.2103889,4.425369,13],
      bounds: null,
      parkeergarages:[]
    };
  },
  methods:{
    
      SelecteerGarage(garage){
         
         var me = this;
        parkeergarageService.ReserveringItems(garage.id).then((data)=>{
          me.$store.commit("SelecteerGarageMap",data.data.result );
        }).catch((err)=>{
          console.log(err)
        })
      }
  }



};
</script>
<style>
.map{
    width: 75px;
    height:100px;
    top:20%;
    min-height: 50%;
    min-width: 100%;
    position: fixed;
    float:right;
    display: block;
}
</style>