﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankForm.DataAccess.Repository.IRepository;

public interface IUnitOfWork 
{
    ITemplateRepository Template { get; }
    ISectionRepository Section { get; }

    void Save();


}
