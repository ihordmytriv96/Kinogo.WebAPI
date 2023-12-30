using Kinogo.WebAPI.Domain.Common.Entities;
using Kinogo.WebAPI.Domain.User.Cons;

namespace Kinogo.WebAPI.Domain.User.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RefreshTokenId { get; set; }
        public string AvatarImgPath { get; set; }
        public UserRoles UserRole { get; set; }
        public bool IsBanned { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
