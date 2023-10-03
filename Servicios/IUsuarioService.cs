using PracticoAppMobil.Modelo;

namespace PracticoAppMobil.Servicios
{
    public interface IUsuarioService
    {
        public Task<List<UsuariosRespose>> Obtener();
        public Task<List<UsuariosRespose>> Filtrar(string searchTerm);
    }
}
