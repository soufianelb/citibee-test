<template>
  <div class="topnav">
 <div class="dropdown">
  <button type="button" class="btn btn-primary dropdown-toggle" style="float:right" data-toggle="dropdown">
   {{gebruiker.gebruikersnaam}}
  </button>
  <div class="dropdown-menu">
    <a class="dropdown-item" href="#">Link 1</a>
 
  </div>
</div>
</div>
</template>

<script>
 
export default {
  name: "Menubar",
  components: {
    
  },  
  props:['gebruiker'],
  data() {
    return {
    };
  }

};
</script>
<style>
.topnav {
  background-color: #5e6161;
  overflow: hidden;
}

 
.topnav a {
  float: right;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

 
.topnav a:hover {
  background-color: #ddd;
  color: black;
}
 
.topnav a.active {
  background-color: #4CAF50;
  color: white;
}
</style>