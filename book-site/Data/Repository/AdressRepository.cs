using book_site.Data.Interfaces;
using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Repository
{
    public class AdressRepository : IAdress
    {
        private readonly AppDBContent appDBContent;

        public AdressRepository(AppDBContent _appDBContent) => appDBContent = _appDBContent;

        public void CreateAdress(Adress adress)
        {
            appDBContent.Adresses.Add(adress);
            appDBContent.SaveChanges();
        }

        public bool EditAdress(Adress adress)
        {
            var editAdress = appDBContent.Adresses.FirstOrDefault(a => a.Id == adress.Id);
            if(editAdress is null)
            {
                return false;
            }

            else
            {
                appDBContent.Adresses.Remove(editAdress);
                appDBContent.Adresses.Add(adress);
                appDBContent.SaveChanges();
                return true;
            }
        }

        public void RemoveAdress(int adressId)
        {
            Adress removeAdress = appDBContent.Adresses.FirstOrDefault(a => a.Id == adressId);
            appDBContent.Adresses.Remove(removeAdress);
            appDBContent.SaveChanges();
        }

        public IEnumerable<Adress> GetAllAdresses => appDBContent.Adresses;

        public Adress GetAdressById(int adressId)
        {
            return appDBContent.Adresses.FirstOrDefault(a => a.Id == adressId);
        }

        public Adress GetAdressByUserId(string userId) => appDBContent.Adresses.FirstOrDefault(a => a.UserId.Equals(userId));

        public IEnumerable<Adress> GetAdressesByUserId(string userId) => appDBContent.Adresses.Where(a => a.UserId.Equals(userId));
    }
}
