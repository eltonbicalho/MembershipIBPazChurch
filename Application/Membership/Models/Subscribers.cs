using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Models
{
    public partial class Subscribers
    {
        [Key]
        public int IdSubscriber { get; set; }
        [Required(ErrorMessage ="O seu nome deve ser informado!")]
        [StringLength(80)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O seu e-mail deve ser informado!")]
        [StringLength(100)]
        [Display(Name = "e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O seu telefone celular deve ser informado!")]
        [StringLength(100)]
        [Display(Name = "Telefone Celular")]
        public string Telefone { get; set; }
        [Display(Name = "Desejo receber mensagens no meu WhatsApp")]
        public bool ReceiveWhatsApp { get; set; }
        [Display(Name = "Desejo receber mensagens no meu e-mail")]
        public bool ReceiveNewsletter { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataUpdate { get; set; }
        public bool Active { get; set; }
    }
}
