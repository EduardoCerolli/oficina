using SharpData;

namespace Oficina.Migrador
{
    public class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            try
            {
                var migrador = new Migrador();
                migrador.Migrar();

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Error running migrator: ");
                Console.WriteLine(ExceptionHelper.GetAllErrors(ex));
                Environment.Exit(-1);
            }
        }
    }
}
