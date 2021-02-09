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
                    throw new Exception("gebruiker bestaat al met dit email adres");
                }
            }
            catch (Exception e) 
            {
                throw new Exception();
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
                    throw new Exception("Foutieve email en of wachtwoord");
                }
            }
            catch (Exception e) 
            {
                throw new Exception("Foutieve email en of wachtwoord");
            }
        }
    }
}
