namespace DonaMaria
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Os tipos de cozinha são gerenciados pelo Form1 (Cadastro de Tipos de Cozinha)
            // Não é necessário configurar tipos fixos aqui

            Application.Run(new FrmMenu());
        }
    }
}