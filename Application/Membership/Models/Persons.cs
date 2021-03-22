using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Models
{
    public partial class Persons
    {
        [Key]
        public int IdPerson { get; set; }
        [Required(ErrorMessage = "O seu primeiro nome deve ser informado!")]
        [StringLength(60)]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O seu sobrenome nome deve ser informado!")]
        [StringLength(60)]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O seu e-mail deve ser informado!")]
        [StringLength(100)]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "e-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O seu telefone celular deve ser informado!")]
        [StringLength(50)]
        public string CellPhone { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        public string AspNetUserID { get; set; }
    }
}
