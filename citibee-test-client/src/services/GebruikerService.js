/* eslint-disable */
import axios from 'axios';
//import AxiosWrapper from '../helpers/AxiosWrapper'
export default class GebruikerService{
    constructor(){
     // this.axiosWrapper = new AxiosWrapper();
    }
    
    Registreren(gebruiker) {
        const options = {
          method: 'POST',
          url:"https://localhost:44390/api/Gebruiker/Registreren",
          data: gebruiker
        };
      return  axios(options) 
       
    }

    Login(gebruiker){
      const options = {
        method: 'POST',
        url:"https://localhost:44390/api/Gebruiker/Aanmelden",
        data: gebruiker
      };
    return  axios(options) 

    }
 
}  