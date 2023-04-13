using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListingPage.Data
{
    public interface IUserDataFactory
    {
        UserDataContext GetUserDataContext();

    }
}
