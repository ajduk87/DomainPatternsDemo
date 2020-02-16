using CommercialClientApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Services
{
    public interface IActionService
    {
        void Insert(Action action);
        void Update(Action action);
        Action Get(string productName);
    }
}
