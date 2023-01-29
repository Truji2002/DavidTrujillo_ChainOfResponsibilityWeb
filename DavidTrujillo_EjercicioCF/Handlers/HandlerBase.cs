using DavidTrujillo_EjercicioCF.Models;
namespace DavidTrujillo_EjercicioCF.Handlers
{
    public abstract class HandlerBase : IHandler
    {
        public IHandler NextHandler { get; set; }

        public virtual void HandleRequest(Sanduche sanduche)
        {
            NextHandler?.HandleRequest(sanduche);
        }
    }

}
