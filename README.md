# Cadastro de produtos em CSV

Programa de console em C# que guarda uma lista de produtos num arquivo CSV e
le de volta. Feito pra praticar leitura e escrita de arquivos.

## O que pratiquei

- `StreamWriter` e `File.ReadLines` pra escrever e ler texto num arquivo
- Separar nome, preco e quantidade numa linha com `;` e juntar de novo com `Split`
- `CultureInfo.InvariantCulture` pra nao salvar o preco com virgula decimal
- Tratar arquivo que nao existe com `File.Exists` antes de tentar ler
- Pular linha malformada (campo faltando ou numero invalido) sem quebrar o programa
- Salvar e ler em UTF-8 pra nao perder acentuacao

## Como rodar

```
dotnet run
```

O programa cria um `produtos.csv` na propria pasta, le ele de volta e depois
mostra o que acontece com um arquivo que nao existe e com uma linha quebrada.
