<template>
  <div class="map">
    <LMap :zoom="zoom" :center="center">
      <LTileLayer :url="url"></LTileLayer>
      <div  v-for="item in lijstParkeergarage" :key="item.id">
    
      <LMarker :lat-lng="[parseFloat(item.lat),parseFloat(item.lng)]"></LMarker>
    </div>
    </LMap>
  </div>
</template>

<script>
 
import { LMap, LTileLayer, LMarker } from "vue2-leaflet";
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