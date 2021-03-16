using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Models
{
    public partial class PreMembros
    {
        [Key]
        public int IdPreMembro { get; set; }
        [Display(Name = "Qual filial você congreja/deseja congregar?")]
        public int IdIgreja { get; set; }
        [Required(ErrorMessage = "O seu nome deve ser informado!")]
        [StringLength(80)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O seu e-mail deve ser informado!")]
        [StringLength(100)]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "e-mail inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O seu telefone celular deve ser informado!")]
        [StringLength(100)]
        public string Telefone { get; set; }

        [Display(Name = "Observações")]
        [StringLength(1000)]
        public string Observacoes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataUpdate { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(IdIgreja))]
        [InverseProperty(nameof(Igrejas.PreMembros))]
        public virtual Igrejas IdIgrejaNavigation { get; set; }
    }
}
