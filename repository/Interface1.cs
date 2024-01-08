using Book.bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface Interface1
    {
       
            IEnumerable<Branchs> GetBranches();
            int Addbook(Branchs branch);

            Branchs GetBranchId(int Branch_Id);

       
    }
}
