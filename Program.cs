using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Informe o CEP: ");
        string cep = Console.ReadLine();

        // Monta a URL com o CEP informado pelo usuário
        string url = $"https://viacep.com.br/ws/{cep}/json/";

        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Se precisar adicionar um cabeçalho de autenticação, descomente a linha abaixo
                // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "seu_token_aqui");

                // Faz a requisição GET para a API
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Lê o conteúdo da resposta como uma string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Resposta da API:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Erro ao buscar o endereço. Código de status: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}
