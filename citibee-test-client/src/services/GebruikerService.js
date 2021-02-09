/* eslint-disable */
import axios from 'axios';
import AxiosWrapper from '../helpers/AxiosWrapper'
export default class GebruikerService{
    constructor(){
      this.axiosWrapper = new AxiosWrapper();
    }
    //TODO deze functie moet naar async return de data en de catch later opvangen in de root om dan de alertyfy op te roepen 1 keer
    //create an axios wrappper
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