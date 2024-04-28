using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreReferenceMyData.Enteties.Enteties
{
    [Table("SubscribeFilm")]
    public class SubscribeFilm
    {
        [Key]
        public int Id { get; set; }

        [Required]

        [StringLength(355)]
        public string SubscribeFilmsData { get; set; }

    }
}
