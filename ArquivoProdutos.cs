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
}
