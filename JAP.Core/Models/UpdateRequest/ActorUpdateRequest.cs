using JAP.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.Models.UpdateRequest
{
    public class ActorUpdateRequest : CreateUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PhotoId { get; set; }

    }
}
