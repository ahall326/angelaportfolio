using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHPortfolio.Models
{
    public class InitialLoad : Employment
    {
        private EmploymentDBEntities db = new EmploymentDBEntities();
        public void LoadUser()
        {
            Address address = new Address
            {
                addressId = 1,
                addressStreet1 = "715 W Straford Dr",
                addressCity = "Chandler",
                addressState = "AZ",
                addressZip = 85225
            };
            db.Addresses.Add(address);
            
            User user = new User
            {
                userFirstName = "Angela",
                userMiddleName = "Renee",
                userLastName = "Hall",
                userEmail = "angelarhall@gmail.com",
                userUSAuthorized = true,
                userAddress = db.Addresses.FirstOrDefault(a => a.addressId == address.addressId)
        };
            user.userId = Guid.NewGuid();
            db.Users.Add(user);
            db.SaveChanges();

        }
        public void LoadCompanies()
        {
            Address address = new Address
            {
                addressId = 2,
                addressCity = "Tempe",
                addressState = "AZ",
                addressStreet1 = "1930 W Rio Salado Pkwy",
                addressZip = 85281
            };
            db.Addresses.Add(address);
            db.SaveChanges();
            Company company = new Company
            {
                companyName = "Carvana",
                companyAddress = db.Addresses.FirstOrDefault(a => a.addressId == address.addressId),
                companyIndustry = "E-commerce / Car dealer",
                companyTelephone = "(800) 333-4554",
                companyType = "Public",
                companyWebsite = "Carvana.com"
            };
            company.companyId = Guid.NewGuid();
            db.Companies.Add(company);
            db.SaveChanges();

            
            
        }
    }
}
