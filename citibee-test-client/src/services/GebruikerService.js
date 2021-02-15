/* eslint-disable */
import axios from 'axios';
export default class GebruikerService{
    constructor(axios){
      this.axiosWrapper = axios;
    }
    
   Registreren(gebruiker) {
        const options = {
          method: 'POST',
          url:`${process.env.VUE_APP_URLAPI}Gebruiker/Registreren`,
          data: gebruiker
        };
      return this.axiosWrapper.Request(options.url, options.method, options.data) 
       
    }

   Login(gebruiker){
      const options = {
        method: 'POST',
        url:`${process.env.VUE_APP_URLAPI}Gebruiker/Aanmelden`,
        data: gebruiker
      };
      return this.axiosWrapper.Request(options.url, options.method, options.data)

    }
 
}  