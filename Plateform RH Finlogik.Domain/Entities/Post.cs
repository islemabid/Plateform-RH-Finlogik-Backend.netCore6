using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string ShortDescription{ get; set; }
        public string LongDescription { get; set; }

        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmployeePost> EmployeePosts { get; set; }



    }
}
