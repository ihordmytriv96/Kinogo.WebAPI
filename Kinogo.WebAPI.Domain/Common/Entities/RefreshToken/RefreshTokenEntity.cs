namespace Kinogo.WebAPI.Domain.Common.Entities.RefreshToken
{
    public class RefreshTokenEntity : BaseEntity
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string UserId { get; set; }
    }
}
