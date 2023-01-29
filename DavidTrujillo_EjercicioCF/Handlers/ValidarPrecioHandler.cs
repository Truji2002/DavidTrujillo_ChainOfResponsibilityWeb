using DavidTrujillo_EjercicioCF.Models;
namespace DavidTrujillo_EjercicioCF.Handlers
{
    public class VerificarRangoPrecioHandler : HandlerBase
    {
        public override void HandleRequest(Sanduche sanduche)
        {
            if (sanduche.Precio < 0 || sanduche.Precio > 20)
            {
                throw new Exception("El precio debe estar entre 0 y 20");
            }

            base.HandleRequest(sanduche);
        }
    }
}
