using System.Text.Json;

namespace EspacioTasks
{
    public static class Tasks
    {
        //metodo para traer los nombres de Plantas o Zombies
        public static async Task<List<string>> GetNombrePersonajes(string tipo){
            var url = $"https://pvz-2-api.vercel.app/api/{tipo}";
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<string>? personajes = JsonSerializer.Deserialize<List<string>>(responseBody);
                return personajes;
            }

            return new List<string>();
        }
    }
}