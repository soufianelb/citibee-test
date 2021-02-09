/* eslint-disable */
import axios from 'axios';
//import AxiosWrapper from '../helpers/AxiosWrapper'
export default class ParkeergarageService{
    constructor(){
     // this.axiosWrapper = new AxiosWrapper();
    }
    //TODO deze functie moet naar async return de data en de catch later opvangen in de root om dan de alertyfy op te roepen 1 keer
    //create an axios wrappper
    Parkeergara() {
        const options = {
          method: 'GET',
          url:"https://localhost:44390/api/Parkeergarage"
         
        };
      return  axios(options) 
       
    }
 
 
}  