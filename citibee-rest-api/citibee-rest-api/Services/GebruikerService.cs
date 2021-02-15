using citibee_rest_api.Dal;
using citibee_rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citibee_rest_api.Services
{
    public class GebruikerService
    {
        private readonly CitibeeContext _citibeeContext;

        public GebruikerService(CitibeeContext citibeeContext) {
            this._citibeeContext = citibeeContext;
        }


        public void Registreer(Gebruiker gebruiker) {
            try 
            {
                if (this._citibeeContext.Gebruiker.Where(x => x.Email.Equals(gebruiker.Email)).FirstOrDefault() == null)
                {
                    this._citibeeContext.Add(gebruiker);
                    this._citibeeContext.SaveChanges();
                }
                else {
                    throw new Exception();
                }
            }
            catch (Exception e) 
            {
                //TODO dit mag normaal niet, zelf error handeling voor schrijven in de service 
                throw new Exception("fout bij aanmaken van de gebruiker");
            }
            
        }

        public Gebruiker GebruikerByEmailWachtwoord(Gebruiker gebruiker) {

            try
            {
             var resultaat= this._citibeeContext.Gebruiker.Where(x => x.Email.Equals(gebruiker.Email)).Where(y=>y.Wachtwoord == gebruiker.Wachtwoord).FirstOrDefault();

                if (resultaat != null)
                {
                    return resultaat;
                }
                else 
                {
                    throw new Exception();    
                }
                
            }
            catch (Exception e) 
            {
                throw new Exception("Wachtwoord en email komen niet overeen");
            }
        }
    }
}
