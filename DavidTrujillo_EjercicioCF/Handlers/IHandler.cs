
using DavidTrujillo_EjercicioCF.Models;
namespace DavidTrujillo_EjercicioCF.Handlers

{
    public interface IHandler
    {
        IHandler NextHandler { get; set; }
        void HandleRequest(Sanduche sanduche);
    }
}
