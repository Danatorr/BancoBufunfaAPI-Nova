using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BancoBufunfaNovo.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Titular { get; set; }
        [Required]
        [MaxLength(14, ErrorMessage = "O cpf pode ter até 14 caracteres!")]
        public int Cpf { get; set; }
        
    }
}
