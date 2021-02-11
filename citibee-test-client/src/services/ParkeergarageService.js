/* eslint-disable */
import axios from 'axios';
//import AxiosWrapper from '../helpers/AxiosWrapper'
export default class ParkeergarageService{
    constructor(){
     // this.axiosWrapper = new AxiosWrapper();
    }
 
    Parkeergarage() {
        const options = {
          method: 'GET',
          url:"https://localhost:44390/api/Parkeergarage"
         
        };
      return  axios(options) 
       
    }
 
    ReserveringItems(id) {
      const options = {
        method: 'GET',
        url:"https://localhost:44390/api/Reserveringitem/Garage?garage="+id
       
      };
    return  axios(options) 
     
    }

    Beschikbaarheid(zoekobj) {
    const options = {
      method: 'POST',
      url:"https://localhost:44390/api/Reserveringitem/CheckBeschikbaar",
      data:zoekobj
     
    };
  return  axios(options) 
   
  }
    BevestigReservatie(obj){
      const options = {
        method: 'POST',
        url:"https://localhost:44390/api/Reserveringitem/Reserveren",
        data:obj
       
      };
    return  axios(options) 
    }
 
}  