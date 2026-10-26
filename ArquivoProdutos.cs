using System.Globalization;

namespace CadastroProdutos;

public class ArquivoProdutos
{
    public static void Salvar(string caminho, List<Produto> produtos)
    {
        using var escritor = new StreamWriter(caminho);
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

        foreach (var linha in File.ReadLines(caminho))
        {
            var campos = linha.Split(';');
            var nome = campos[0];
            var preco = decimal.Parse(campos[1], CultureInfo.InvariantCulture);
            var quantidade = int.Parse(campos[2]);
            produtos.Add(new Produto(nome, preco, quantidade));
        }

        return produtos;
    }
}
