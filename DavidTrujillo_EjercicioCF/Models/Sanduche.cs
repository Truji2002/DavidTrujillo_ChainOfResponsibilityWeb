using System.ComponentModel.DataAnnotations;

namespace DavidTrujillo_EjercicioCF.Models
{
    public class Sanduche
    {
        public int Id { get; set; }


        [Required]
        public string? Nombre { get; set; }

        public bool ConQueso { get; set; }

        public bool ConVegetales { get; set; }

        [VerificarRango]
        public decimal Precio { get; set; }
    }

    public class VerificarRango : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            decimal valor1 = (decimal)value;
            if (valor1 < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
