﻿namespace RH.API.Domain;

public class Produtos
{
    public int ProdutoId { get; set; }
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public int QtdEstoque { get; set; }
}
