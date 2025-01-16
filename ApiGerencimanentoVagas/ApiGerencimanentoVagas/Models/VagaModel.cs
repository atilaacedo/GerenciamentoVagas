using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiGerencimanentoVagas.Models.Enums;

namespace ApiGerencimanentoVagas.Models
{
    public class VagaModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public StatusVaga Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created_at { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]   
        public DateTime Updated_at { get; set; }
    }
}
