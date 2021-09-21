using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Contracts
{
    public class CommandBase<T>:IRequest<T> where T:class
    {
    }
}
