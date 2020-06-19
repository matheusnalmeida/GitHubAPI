using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGitHubAPI.Models.api_requisition_classes
{
    interface IApiRequisitionInterface<T>
    {
        public T RealizaConexao();

    }

}
