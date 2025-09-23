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

            // Carrega dados de exemplo se não existirem dados salvos
            LoadSampleDataIfNeeded();

            Application.Run(new FrmMenu());
        }

        private static void LoadSampleDataIfNeeded()
        {
            try
            {
                // Verifica se já existem dados salvos
                var existingRecipes = RecipeRepository.GetAll();
                var existingKitchenTypes = KitchenTypeManager.GetKitchenTypes();
                var existingIngredients = IngredientRepository.GetAll();

                // Se não há dados, carrega os dados de exemplo
                if (existingRecipes.Count == 0 || existingKitchenTypes.Count <= 4 || existingIngredients.Count == 0)
                {
                    SampleData.LoadSampleData();
                }
            }
            catch
            {
                // Em caso de erro, tenta carregar os dados de exemplo mesmo assim
                try
                {
                    SampleData.LoadSampleData();
                }
                catch
                {
                    // Se falhar, continua sem os dados de exemplo
                }
            }
        }
    }
}