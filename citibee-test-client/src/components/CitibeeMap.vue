<template>
  <div style="height: 40vh">
    <LMap :zoom="zoom" :center="center">
      <LTileLayer :url="url"></LTileLayer>
      <LMarker :lat-lng="[13.1333682,77.5651881]"></LMarker>
      <LMarker :lat-lng="[13.1340669,77.56707]"></LMarker>
      <LMarker :lat-lng="[13.1348904,77.5643231]"></LMarker>
      <LMarker :lat-lng="[13.1367826,77.5711133]"></LMarker>
    </LMap>
  </div>
</template>

<script>
//meegeven met props dit public insts string test dit zeker nog als te voren

// na dat alles oke is check alles en doe dan aan error handeling
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
      zoom: 16,
      center: [13.1367826,77.5711133],
      bounds: null,
      parkeergarages:[]
    };
  }

};
</script>