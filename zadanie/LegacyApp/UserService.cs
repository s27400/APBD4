using System;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepostiory;
        private IUserCreditService _userCreditService;

        public UserService()
        {
            _clientRepostiory = new ClientRepository();
            _userCreditService = new UserCreditService();
        }

        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService)
        {
            _clientRepostiory = clientRepository;
            _userCreditService = userCreditService;
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            //UserValidation firstName, lastName, email
            UserValidator validator = new UserValidator(firstName, lastName, email);
            if (!validator.UserValidate())
            {
                return false;
            }
            
            //User`s age to function AgeCalculator
            if (AgeCalculator(dateOfBirth) < 21)
            {
                return false;
            }

            //Injection in Constructor
            var client = _clientRepostiory.GetById(clientId);

            //UserCreating to function
            var user = CreateUser(firstName, lastName, email, dateOfBirth, client);
            
            //If changed on switch + Injection in Constructor
            switch (client.Type)
            {
                case("VeryImportantClient"):
                {
                    user.HasCreditLimit = false;
                    break;
                }
                case ("ImportantClient"):
                {
                        int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        creditLimit = creditLimit * 2;
                        user.CreditLimit = creditLimit;
                    break;
                }
                default:
                {
                    user.HasCreditLimit = true;
                    int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                    break;
                }
            }

            //Credit Checking in User Class
            if (!user.CreditChecker())
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
        private int AgeCalculator(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }

        private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
        {
            return new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
