/* eslint-disable */
import axios from 'axios';
export default class GebruikerService{
    constructor(axios){
      this.axiosWrapper = axios;
    }
    
   Registreren(gebruiker) {
        const options = {
          method: 'POST',
          url:"https://localhost:44390/api/Gebruiker/Registreren",
          data: gebruiker
        };
      return this.axiosWrapper.Request(options.url, options.method, options.data) 
       
    }

   Login(gebruiker){
      const options = {
        method: 'POST',
        url:"https://localhost:44390/api/Gebruiker/Aanmelden",
        data: gebruiker
      };
      return this.axiosWrapper.Request(options.url, options.method, options.data)

    }
 
}  