using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Provider
    {

        private string _password;

        private string _confirmPassword;

        [Key]
        public int ProviderId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Length >= 5 && value.Length <= 20)
                    _password = value;
                else
                    Console.WriteLine("Le mot de passe doit être compris entre 5 et 20 caractères.");
            }
        }

        [Required]
        [NotMapped] //ne soit pas mappé dans la DB 
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Cconfirm password doit avoir la meme valeur que password")] //compare ConfirmPassword à Password 
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                if (value.Equals(Password))
                    _confirmPassword = value;
                else
                    Console.WriteLine("Le confirm password est different du password ");
            }

        }

        public DateTime DateCreated { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool IsApproved { get; set; }




        public string UserName { get; set; }
        public virtual List<Product> Products { get; set; }

        public Provider()
        {

        }

        public Provider(string confirmPassword, DateTime dateCreated, string email, bool isApproved, string password, string userName)
        {
            ConfirmPassword = confirmPassword;
            DateCreated = dateCreated;
            Email = email;
            IsApproved = isApproved;
            Password = password;
            UserName = userName;
        }

        public override string ToString()
        {
            return $"{nameof(ConfirmPassword)}: {ConfirmPassword}, {nameof(DateCreated)}: {DateCreated}, {nameof(Email)}: {Email}, {nameof(IsApproved)}: {IsApproved}, {nameof(Password)}: {Password}, {nameof(UserName)}: {UserName}";
        }

        //Polymorphisme
        public bool Login(string nomUser, string passwordUser)
        {
            Console.WriteLine("Vous etes connecté");
            return (String.Compare(nomUser, UserName) == 0 && String.Compare(passwordUser, Password) == 0);

        }

        public bool Login(string nomUser, string passwordUser, string emailUser)
        {
            return (String.Compare(nomUser, UserName) == 0 && String.Compare(passwordUser, Password) == 0 && String.Compare(emailUser, Email) == 0);

        }

        //passage par réference
        public static void SetIsApproved(Provider P)
        {
            if (String.Compare(P.Password, P.ConfirmPassword) == 0)
            {
                P.IsApproved = true;
                Console.WriteLine("le password et le confirm password sont identiques");
            }
            else
            {
                P.IsApproved = false;
                Console.WriteLine("le password et le confirm password sont differents");
            }
        }

        //passage par valeur pour l'attribut IsApproved 
        public static void SetIsApproved(string password, string confirmPassword, bool isApproved)
        {

            if (String.Compare(password, confirmPassword) == 0)
            {
                isApproved = true;
                Console.WriteLine("le password et le confirm password sont identiques");
            }
            else
            {
                isApproved = false;
                Console.WriteLine("le password et le confirm password sont differents");
            }
        }


        public List<Product> GetProducts(string filterType, string filterValue)
        {
            List<Product> l = new List<Product>(); //creation d'une liste vide
            switch (filterType)
            {
                case "Name":
                    foreach (Product p in Products)
                    {
                        if (p.Name.Equals(filterValue))
                        {
                            l.Add(p);
                        }
                    }
                    break;

                case "Price":
                    foreach (Product p in Products)
                    {
                        if (p.Price == float.Parse(filterValue))
                        {
                            l.Add(p);
                        }
                    }
                    break;

            }
            return l;

        }

    }

}
