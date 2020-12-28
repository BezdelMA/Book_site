using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Interfaces
{
    public interface IAdress
    {
        void CreateAdress(Adress adress);

        bool EditAdress(Adress adress);

        void RemoveAdress(int adressId);

        IEnumerable<Adress> GetAllAdresses { get;}
        Adress GetAdressById(int adressId);

        Adress GetAdressByUserId(string userId);
        IEnumerable<Adress> GetAdressesByUserId(string userId);
    }
}
