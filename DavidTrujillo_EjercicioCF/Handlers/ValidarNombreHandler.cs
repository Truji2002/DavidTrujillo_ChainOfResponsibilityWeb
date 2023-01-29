using DavidTrujillo_EjercicioCF.Models; 
namespace DavidTrujillo_EjercicioCF.Handlers
{
    public class ValidarNombreHandler : HandlerBase
    {
        public override void HandleRequest(Sanduche sanduche)
        {
            if (string.IsNullOrEmpty(sanduche.Nombre))
            {
                throw new Exception("El nombre es requerido");
            }

            base.HandleRequest(sanduche);
        }
    }
}
