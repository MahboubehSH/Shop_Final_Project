using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace AccountManagement.Application.Contracts.Role
{
    public  class CreateRole
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        public List<int> Permissions { get; set; }
    }
}
 