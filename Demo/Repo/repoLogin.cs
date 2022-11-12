using Demo.Entity;
using Demo.Models;

namespace Demo.Repo
{
    public class repoLogin : IrepoLogin
    {
        private readonly CarDetailsDbContext _context;

        public repoLogin(CarDetailsDbContext context) 
        {
            _context=context;
        }

        public login registration(login l)
        {
            _context.logins.Add(l);
            _context.SaveChanges();

            return l;
            
        }
    }
}
