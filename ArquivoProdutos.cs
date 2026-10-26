using System.Globalization;
using System.Text;

namespace CadastroProdutos;

public class ArquivoProdutos
{
    public static void Salvar(string caminho, List<Produto> produtos)
    {
        using var escritor = new StreamWriter(caminho, false, Encoding.UTF8);
        foreach (var p in produtos)
        {
            // CultureInfo invariante pra nao salvar o preco com virgula
            var linha = $"{p.Nome};{p.Preco.ToString(CultureInfo.InvariantCulture)};{p.Quantidade}";
            escritor.WriteLine(linha);
        }
    }

    public static List<Produto> Carregar(string caminho)
    {
        var produtos = new List<Produto>();

        if (!File.Exists(caminho))
        {
            Console.WriteLine($"Arquivo {caminho} nao existe, comecando com lista vazia");
            return produtos;
        }

        foreach (var linha in File.ReadLines(caminho, Encoding.UTF8))
        {
            var campos = linha.Split(';');

            // se a linha nao tem os 3 campos ou o numero nao converte, ela e pulada
            if (campos.Length != 3)
            {
                Console.WriteLine($"Linha ignorada (formato invalido): {linha}");
                continue;
            }

            try
            {
                var nome = campos[0];
                var preco = decimal.Parse(campos[1], CultureInfo.InvariantCulture);
                var quantidade = int.Parse(campos[2]);
                produtos.Add(new Produto(nome, preco, quantidade));
            }
            catch (FormatException)
            {
                Console.WriteLine($"Linha ignorada (numero invalido): {linha}");
            }
        }

        return produtos;
    }
}
