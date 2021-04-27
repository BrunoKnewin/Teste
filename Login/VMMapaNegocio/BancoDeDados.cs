using VMBrevisCore.Gerenciador;

namespace VMMapaNegocio
{
    public class BancoDeDados
    {
       internal Busca busca = new   Busca (@"E:\TesteKnewin\Knewin\Login\VMMapa");
       internal Inclui inclui = new Inclui(@"E:\TesteKnewin\Knewin\Login\VMMapa");
       internal Altera altera = new Altera(@"E:\TesteKnewin\Knewin\Login\VMMapa");
       internal Remove remove = new Remove(@"E:\TesteKnewin\Knewin\Login\VMMapa");
    }
}
