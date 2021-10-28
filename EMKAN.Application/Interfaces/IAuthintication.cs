using EMKAN.Entity.ModelDto;

namespace EMKAN.Application.Interfaces
{
    public  interface IAuthintication
    {
     public string  Authinticate(string username, string password);
        public string Auth(UserDto user);
    }
}
