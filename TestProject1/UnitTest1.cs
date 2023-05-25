using PPC;
namespace TestProject1
{
    public class AuthorizationTest
    {
        [Fact]
        public void Test1()
        {
            int NumberSotr;
            int NumberSotrAuth = 0;
            List<Date_Users> Users;
            using (UserContext db = new UserContext())
            {
                Users = db.Date_Users.ToList();
            }
            NumberSotr = Users.Count;
            foreach (var i in Users)
            {
                Authtorization.GetAuthorization().Login = i.Login;
                Authtorization.GetAuthorization().Password = i.Password;
                if(Authtorization.GetAuthorization().Authorization() == i) NumberSotrAuth++;
            }
            Assert.Equal(NumberSotr, NumberSotrAuth);
        }
    }
}