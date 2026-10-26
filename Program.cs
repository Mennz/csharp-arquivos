using CadastroProdutos;

var produtos = new List<Produto>
{
    new Produto("Arroz", 24.90m, 10),
    new Produto("Feijao", 8.50m, 20),
    new Produto("Acucar", 5.20m, 15)
};

foreach (var p in produtos)
{
    Console.WriteLine(p);
}
