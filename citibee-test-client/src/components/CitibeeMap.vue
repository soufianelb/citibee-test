<template>
  <div class="map">
    <LMap :zoom="mapsParams.zoom" :center="mapsParams.center">
      <LTileLayer :url="mapsParams.url"></LTileLayer>
      <div v-for="item in lijstParkeergarage" :key="item.id">
      <LMarker @click="SelecteerGarage(item)" :lat-lng="[parseFloat(item.lat),parseFloat(item.lng)]"></LMarker>
    </div>
    </LMap>
  </div>
</template>

<script>
 
import { LMap, LTileLayer, LMarker } from "vue2-leaflet";
import {mapState} from 'vuex'
import ParkeergarageService from '../services/ParkeergarageService'
    const parkeergarageService = new ParkeergarageService();
export default {
  name: "CitibeeMap",
  components: {
    LMap,
    LTileLayer,
    LMarker
  },
  props: ['lijstParkeergarage', 'mapsParams'],
  data() {
    return {
      parkeergarages:[]
    };
  },
  computed:mapState(['zoekObject']), 
  watch:{
      zoekObject(){
        this.mapsParams.zoom =20;
        this.mapsParams.center = [parseFloat(this.zoekObject.lat),parseFloat(this.zoekObject.lng)]
        this.SelecteerGarage(this.zoekObject);
      }
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