namespace RH.API.Domain
{
    public class Biblioteca
    {
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public int AnoPublicacao { get; set; }
        public int CodigoDeBarras { get; set; }
        public string Status { get; set; } = "Disponível";
    }
}
