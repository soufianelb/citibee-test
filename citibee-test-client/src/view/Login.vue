<template>
<div>
 <div class="container px-4 py-5 mx-auto">
    <div class="card card0" v-if="isAanmelden == true">
    <div class="row justify-content-center my-3 px-3">
       <div class="col-md-8 col-10 my-5">
        <label name="email" class="form-control-label text-muted" for="email">Email:</label>
        <input type="text" class="form-control" name="email" for="email" v-model="gebruiker.email" placeholer="Email"/><br>
        
        <label name="wachtwoord" class="form-control-label text-muted" for="wachtwoord">Wachtwoord:</label>
        <input type="password" class="form-control" name="wachtwoord" for="wachtwoord" v-model="gebruiker.wachtwoord" placeholer="Wachtwoord"/><br>

         
        <button @click="Aanmelden()" class="btn-block btn-color">Aanmelden</button>
        </div>
        </div>
        <label class="sm-text mx-auto mb-3" @click="AanmeldenRegistreren()">Nog geen account? Registreer je dan</label>
    </div>

      <div class="card card0" v-else>
        <div class="row justify-content-center my-3 px-3">
         <div class="col-md-8 col-10 my-5">
        <label name="email" class="form-control-label text-muted"  for="email">Email:</label>
        <input type="text"  name="email" for="email" v-model="gebruiker.email" placeholer="Email"/><br>
        
        <label name="gebruikersnaam" class="form-control-label text-muted"  for="gebruikersnaam">Gebruikersnaam:</label>
        <input type="text"  name="gebruikersnaam" for="gebruikersnaam" v-model="gebruiker.gebruikersnaam" placeholer="Gebruikersnaam"/><br>
        
        <label name="voornaam" class="form-control-label text-muted"  for="voornaam">Voornaam:</label>
        <input type="text"  name="voornaam" for="voornaam" v-model="gebruiker.voornaam" placeholer="Voornaam"/><br>
        
        <label name="familienaam" class="form-control-label text-muted"  for="familienaam">Familienaam:</label>
        <input type="text"  name="familienaam" for="familienaam" v-model="gebruiker.familienaam" placeholer="email"/><br>
        
        <label name="wachtwoord" class="form-control-label text-muted"  for="wachtwoord">Wachtwoord:</label>
        <input type="password"  name="wachtwoord" for="wachtwoord" v-model="gebruiker.wachtwoord" placeholer="Wachtwoord"/><br>

        <button @click="Registreren()" class="btn-block btn-color">Registreren</button>
        </div>
        </div>
        <label class="sm-text mx-auto mb-3" @click="AanmeldenRegistreren()">Aanmelden</label>
    </div>
 </div>
 </div>
</template>

<script>
export default {
  name: 'Login',
   data(){
       return{
           gebruiker:{},
           isAanmelden:true,
        
       }
   },
   created(){

   },

   methods:{
       AanmeldenRegistreren(){
           if(this.isAanmelden == true){
               this.isAanmelden = false;
           }
           else{
               this.isAanmelden =true;
           }
       },
         Registreren(){
         var me = this;
         if(me.gebruiker){
          me.$GebruikerService.Registreren(me.gebruiker).then(()=>{
              this.isAanmelden = true;
          });
            
        }
      },
        Aanmelden(){
        var me = this;
        if(me.gebruiker){
            me.$GebruikerService.Login(me.gebruiker).then((data)=>{
            console.log(data)
            me.$emit("aanmelden", data.result)
               
           });
          
        }
      }
   }
}
</script>

<style>
 .loginbody {
    color: #000;
    overflow-x: hidden;
    height: 100%;
    background-image: linear-gradient(to right, #D500F9, #FFD54F);
    background-repeat: repeat
}

input,
textarea {
    background-color: #F3E5F5;
    border-radius: 50px !important;
    padding: 12px 15px 12px 15px !important;
    width: 100%;
    box-sizing: border-box;
    border: none !important;
    border: 1px solid #F3E5F5 !important;
    font-size: 16px !important;
    color: #000 !important;
    font-weight: 400
}

input:focus,
textarea:focus {
    -moz-box-shadow: none !important;
    -webkit-box-shadow: none !important;
    box-shadow: none !important;
    border: 1px solid #D500F9 !important;
    outline-width: 0;
    font-weight: 400
}

button:focus {
    -moz-box-shadow: none !important;
    -webkit-box-shadow: none !important;
    box-shadow: none !important;
    outline-width: 0
}

.card {
    border-radius: 0;
    border: none
}

.card1 {
    width: 50%;
    padding: 40px 30px 10px 30px
}

.card2 {
    width: 50%;
    background-image: linear-gradient(to right, #FFD54F, #D500F9)
}

#logo {
    width: 70px;
    height: 60px
}

.heading {
    margin-bottom: 60px !important
}

::placeholder {
    color: #000 !important;
    opacity: 1
}

:-ms-input-placeholder {
    color: #000 !important
}

::-ms-input-placeholder {
    color: #000 !important
}

.form-control-label {
    font-size: 12px;
    margin-left: 15px
}

.msg-info {
    padding-left: 15px;
    margin-bottom: 30px
}

.btn-color {
    border-radius: 50px;
    color: #fff;
    background-image: linear-gradient(to right, #FFD54F, #D500F9);
    padding: 15px;
    cursor: pointer;
    border: none !important;
    margin-top: 40px
}

.btn-color:hover {
    color: #fff;
    background-image: linear-gradient(to right, #D500F9, #FFD54F)
}

.btn-white {
    border-radius: 50px;
    color: #D500F9;
    background-color: #fff;
    padding: 8px 40px;
    cursor: pointer;
    border: 2px solid #D500F9 !important
}

.btn-white:hover {
    color: #fff;
    background-image: linear-gradient(to right, #FFD54F, #D500F9)
}

a {
    color: #000
}

a:hover {
    color: #000
}

.bottom {
    width: 100%;
    margin-top: 50px !important
}

.sm-text {
    font-size: 15px
}

@media screen and (max-width: 992px) {
    .card1 {
        width: 100%;
        padding: 40px 30px 10px 30px
    }

    .card2 {
        width: 100%
    }

    .right {
        margin-top: 100px !important;
        margin-bottom: 100px !important
    }
}

@media screen and (max-width: 768px) {
    .container {
        padding: 10px !important
    }

    .card2 {
        padding: 50px
    }

    .right {
        margin-top: 50px !important;
        margin-bottom: 50px !important
    }
}
</style>
