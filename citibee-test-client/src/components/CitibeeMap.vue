<template>
  <div class="map">
    <LMap :zoom="mapsParams.zoom" :center="mapsParams.center">
      <LTileLayer :url="mapsParams.url"></LTileLayer>
      <div v-for="item in lijstParkeergarage" :key="item.id">
      <LMarker @click="SelecteerGarage(item)" :lat-lng="[parseFloat(item.lat),parseFloat(item.lng)]">
      <l-icon :icon-url="require('@/assets/images/parking.jpg')" />
      </LMarker>
    </div>
    </LMap>
  </div>
</template>

<script>
 
import { LMap, LTileLayer, LMarker, LIcon } from "vue2-leaflet";
import {mapState} from 'vuex'
export default {
  name: "CitibeeMap",
  components: {
    LMap,
    LTileLayer,
    LMarker,
    LIcon
  },
  props: ['lijstParkeergarage', 'mapsParams'],
  data() {
    return {
      
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
        me.$ParkeergarageService.ReserveringItems(garage.id).then((data)=>{
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