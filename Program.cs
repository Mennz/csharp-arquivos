using CadastroProdutos;

var produtos = new List<Produto>
{
    new Produto("Arroz", 24.90m, 10),
    new Produto("Feijao", 8.50m, 20),
    new Produto("Acucar", 5.20m, 15),
    new Produto("Cafe em pó", 15.75m, 8)
};

var caminho = "produtos.csv";
ArquivoProdutos.Salvar(caminho, produtos);
Console.WriteLine($"Produtos salvos em {caminho}");

var carregados = ArquivoProdutos.Carregar(caminho);
Console.WriteLine("\nProdutos lidos de volta:");
foreach (var p in carregados)
{
    Console.WriteLine(p);
}

Console.WriteLine("\nTestando arquivo que nao existe:");
ArquivoProdutos.Carregar("nao_existe.csv");

Console.WriteLine("\nTestando linha malformada no meio do arquivo:");
File.AppendAllText(caminho, "linha sem os campos certos\n");
ArquivoProdutos.Carregar(caminho);
