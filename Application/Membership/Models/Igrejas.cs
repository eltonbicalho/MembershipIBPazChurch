using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Models
{
    public partial class Igrejas
    {
        public Igrejas()
        {
            PreMembros = new HashSet<PreMembros>();
        }

        [Key]
        public int IdIgreja { get; set; }
        [StringLength(80)]
        [Required(ErrorMessage = "O nome deve ser informado!")]
        [Display(Name = "Nome da Igreja")]
        public string Nome { get; set; }

        [InverseProperty("IdIgrejaNavigation")]
        public virtual ICollection<PreMembros> PreMembros { get; set; }
    }
}
