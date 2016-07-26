using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService:IUserService<UserExtended>
    {
        
        public UserRepository userRepository;
        public AddressRepository addressRepository;
        public UserService()
        {
            userRepository = new UserRepository(Constants.userCollection, Constants.userDatabase);
            addressRepository = new AddressRepository(Constants.addressCollection, Constants.userDatabase);

        }
        public void Delete(UserExtended e)
        {
            try
            {
                userRepository.Delete(e.user);
            }
            catch (Repository.NotFoundEntityEx ex)
            {
                throw new NotFoundEntityEx(ex.Message);
            }

            List<Address> la;
            
            try
            {
                la = addressRepository.GetAll();
            }
            catch (Repository.NotFoundEntityEx ex)
            {
                throw new NotFoundEntityEx(ex.Message+"address collection is empty");
            }

            foreach (Address a in la)
            {
                if (a.UserId == e.user.Id)
                {
                    addressRepository.Delete(a);
                }
            }
        }
        
        public UserExtended GetById(Guid id)
        {

            User u;
            List<Address> la;
            List<UserAddress> uAddr = new List<UserAddress>();
            try
            {
                u = userRepository.GetById(id);
            }
            catch (Repository.NotFoundEntityEx ex)
            {
                throw new NotFoundEntityEx(ex.Message+"user not found");
            }
            try
            {
                 la = addressRepository.GetAll();
            }
            catch (Repository.NotFoundEntityEx ex)
            {
                throw new NotFoundEntityEx(ex.Message+"address collection is empty");
            }

            foreach (Address a in la)
            {
                if (a.UserId == u.Id)
                    uAddr.Add(new UserAddress() { city = a.city, country = a.country, number = a.number, street = a.street });
            }
            return new UserExtended() { user = u, address =new List<UserAddress>(uAddr) };
        }
        public List<UserExtended> GetAll()
        {
            List<User> lu;
            List<Address> la;
            List<UserAddress> uAddr = new List<UserAddress>();
            List<UserExtended> uel = new List<UserExtended>();
            try
            {
                lu = userRepository.GetAll();
            }
            catch (Repository.NotFoundEntityEx ex)
            {
                throw new NotFoundEntityEx(ex.Message);
            }
            try
            {
                la = addressRepository.GetAll();
            }
            catch (Repository.NotFoundEntityEx ex)
            {
                throw new NotFoundEntityEx(ex.Message);
            }

            foreach (User u in lu)
            {
                foreach (Address a in la)
                {
                    if (a.UserId == u.Id)
                    {
                        uAddr.Add(new UserAddress() { city = a.city, country = a.country, number = a.number, street = a.street });
                    }
                }
                uel.Add(new UserExtended() { user = u, address=new List<UserAddress>(uAddr) });
                uAddr.Clear();
            }


            return uel;
        }

        public UserExtended Insert(UserExtended e)
        {
            try
            {
                if (e.user.firstName == null || e.user.lastName == null || e.user.username == null || e.user.password == null || e.address.Count == 0)
                {
                    throw new Exception("You must fill all fields");
                }
            }
            catch (NullReferenceException)
            {
                throw new Exception("You must fill all fields");
            }

            User u = userRepository.Insert(e.user);

            foreach (UserAddress ua in e.address)
            {
                Address a = new Address() { UserId = e.user.Id, city = ua.city, country = ua.country, number = ua.number, street = ua.street };
                addressRepository.Insert(a);
            }

            return new UserExtended() { user = u, address = new List<UserAddress>(e.address) };
        }

        public void Update(UserExtended e)
        {
            try
            {
                userRepository.Update(e.user);
            }
            catch (Repository.NotFoundEntityEx ex)
            {
                throw new NotFoundEntityEx(ex.Message+"not found user to update ");
            }
            List<Address> la;
            try
            {
                la = addressRepository.GetAll();
            }
            catch (Repository.NotFoundEntityEx ex)
            {
                throw new NotFoundEntityEx(ex.Message);
            }

            la=la.AsQueryable().Where(x => e.user.Id == x.UserId).ToList();

            foreach (Address a in la)
            {
                try
                {
                    addressRepository.Delete(a);
                }
                catch (Repository.NotFoundEntityEx ex)
                {
                    throw new NotFoundEntityEx(ex.Message);
                }
            } 
            foreach (UserAddress ua in e.address)
            {
                Address a = new Address() { UserId = e.user.Id, city = ua.city, country = ua.country, number = ua.number, street = ua.street };
                addressRepository.Insert(a);
            }
        }
    }
}
