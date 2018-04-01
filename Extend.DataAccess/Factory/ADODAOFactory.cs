using Extend.DataAccess.DAO;
using Extend.DataAccess.DAOImpl;

namespace Extend.DataAccess
{
    public class ADODAOFactory : AbstractDAOFactory
    {
        public override IAccountDAO CreateAccountDao()
        {
            return new AccountDAOlmpl();
        }
    }
}