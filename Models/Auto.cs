using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIDSolutions.Models
{
    [Table(name: "Autos")]
public class Auto
    {
        [Key]
        public string Placa { get; set; }

        public string Marca { get; set; }

        public int Fabricacion { get; set; }

        public string Propietario { get; set; }

        public string Email { get; set; }

        public decimal Valor { get; set; }

        public DateTime Inspeccion { get; set; }

        public bool Disponible { get; set; }
    }

    public class AutoContext : DbContext
    {
        public AutoContext(DbContextOptions options) : base(options) { }
        public DbSet<Auto> Autos { get; set; }
    }


}
