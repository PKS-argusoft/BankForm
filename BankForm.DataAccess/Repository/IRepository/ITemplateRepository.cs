using BankForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankForm.DataAccess.Repository.IRepository
{
    internal interface ITemplateRepository : IRepository<Template>
    {
        void Update(Template obj);
    }
}
