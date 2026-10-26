using CadastroProdutos;

var produtos = new List<Produto>
{
    new Produto("Arroz", 24.90m, 10),
    new Produto("Feijao", 8.50m, 20),
    new Produto("Acucar", 5.20m, 15)
};

var caminho = "produtos.csv";
ArquivoProdutos.Salvar(caminho, produtos);
Console.WriteLine($"Produtos salvos em {caminho}");
