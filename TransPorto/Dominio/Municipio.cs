namespace Dominio
{
    public class Municipio : Entidade
    {
        public Municipio()
        {
            Estado = new Estado();
        }

        public Estado Estado { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }
    }
}