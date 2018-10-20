using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConnectionSQL_webAPI_.Models
{
    public class UserRecords
    {
        public int UserId { get; set; }

        [DisplayName("First Name:")]
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        [DisplayName("MIddle Name:")]
        [Required(ErrorMessage = "This field is required.")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }
        [DisplayName("Email:")]
        [Required(ErrorMessage = "This field is required.")]
        public string EmailAddress { get; set; }
        [DisplayName("Contact:")]
        [Required(ErrorMessage = "This field is required.")]
        public string PhoneNumber { get; set; }
        [DisplayName("Password:")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public List<UserRecords> userinfo { get; set; }

        [DisplayName("Unique ID No:")]
        [Required(ErrorMessage = "This field is required.")]
        public string UserUniqueId { get; set; }
        [DisplayName("User Type:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> UserTypeId { get; set; }
        public Nullable<int> AddressId { get; set; }

        [DisplayName("Address Line 1:")]
        [Required(ErrorMessage = "This field is required.")]
        public string AddressLine1 { get; set; }
        [DisplayName("Address Line 2:")]
        public string AddressLine2 { get; set; }
        [DisplayName("Pincode:")]
        [Required(ErrorMessage = "This field is required.")]
        public string Pincode { get; set; }
        [DisplayName("City:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> CityId { get; set; }
        [DisplayName("State:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> StateId { get; set; }
        [DisplayName("Country:")]
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> CountryId { get; set; }


        public Nullable<System.Guid> ActivationCode { get; set; }
        public string ResetPasswordCode { get; set; }

        public virtual Address Address { get; set; }
        public List<UserType> UserTypesCollection { get; set; }
        public List<Country> CountriesCollection { get; set; }
        public List<State> StatesCollection { get; set; }
        public List<City> CitiesCollection { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}