using PracticoAppMobil.Modelo;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace PracticoAppMobil.Servicios
{
    public class UsuarioService: IUsuarioService
    {
        private String urlApi = "https://localhost:44337/api/UsuariosApi"; //lo probe con windows machine ya que al consumir el rest no pude configurar para que tengan lamisma red o consumirlo por ip
        public async Task<List<UsuariosRespose>> Obtener()
        {
            var client = new HttpClient();
            var response= await client.GetAsync(urlApi); 
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode resultNode = JsonNode.Parse(responseBody);
            //JsonNode result = resultNode["results"];//aca esto no se si es nesesario para mi servicio

            var usuarioData = JsonSerializer.Deserialize<List<UsuariosRespose>>(resultNode.ToString());
            return usuarioData;
        }

        public async Task<List<UsuariosRespose>> Filtrar(string searchTerm)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync($"https://localhost:44337/api/UsuariosApi/search?searchTerm={searchTerm}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JsonNode resultNode = JsonNode.Parse(content);
                    //var filteredUsers = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(content);
                    var filteredUsers = JsonSerializer.Deserialize<List<UsuariosRespose>>(resultNode.ToString());

                    return filteredUsers;
                }
                else
                {
                    // Maneja el error, por ejemplo, muestra un mensaje al usuario o registra el error
                    return new List<UsuariosRespose>();
                }
            }
            catch (Exception ex)
            {
                // Maneja excepciones, por ejemplo, registra el error
                return new List<UsuariosRespose>();
            }
        }
    }
}
