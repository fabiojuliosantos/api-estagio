namespace RH.API.Domain;

public static class VendaCalcularValorTotal
{
    public static double CalcularValorTotal(double preco, int quantidade)
    {
        if (preco <= 0 || quantidade <= 0)
        {
            throw new Exception("Preço e quantidade devem ser maiores que zero");
        }
        return preco * quantidade;
    }
}