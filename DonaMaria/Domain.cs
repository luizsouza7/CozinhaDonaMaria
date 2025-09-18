using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace DonaMaria
{
    public class IngredientItem
    {
        public string Nome { get; set; } = string.Empty;
        public string Quantidade { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }

    public class Recipe
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string TipoCozinha { get; set; } = string.Empty;
        public int TempoPreparoMinutos { get; set; }
        public int Porcoes { get; set; }
        public string ModoPreparo { get; set; } = string.Empty;
        public string? Utensilios { get; set; }
        public string? Observacoes { get; set; }
        public List<IngredientItem> Ingredientes { get; set; } = new List<IngredientItem>();
    }

    public static class RecipeRepository
    {
        private static readonly object _lock = new object();
        private static readonly List<Recipe> _recipes = new List<Recipe>();
        private static readonly string _dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DonaMaria");
        private static readonly string _dataFilePath = Path.Combine(_dataDirectory, "recipes.json");

        static RecipeRepository()
        {
            TryLoadFromDisk();
        }

        public static void AddOrUpdate(Recipe recipe)
        {
            if (recipe == null) throw new ArgumentNullException(nameof(recipe));
            lock (_lock)
            {
                var existing = _recipes.FirstOrDefault(r => string.Equals(r.Codigo, recipe.Codigo, StringComparison.OrdinalIgnoreCase));
                if (existing == null)
                {
                    _recipes.Add(recipe);
                }
                else
                {
                    // Atualiza campos
                    existing.Nome = recipe.Nome;
                    existing.TipoCozinha = recipe.TipoCozinha;
                    existing.TempoPreparoMinutos = recipe.TempoPreparoMinutos;
                    existing.Porcoes = recipe.Porcoes;
                    existing.ModoPreparo = recipe.ModoPreparo;
                    existing.Utensilios = recipe.Utensilios;
                    existing.Observacoes = recipe.Observacoes;
                    existing.Ingredientes = recipe.Ingredientes;
                }
                TrySaveToDisk();
            }
        }

        public static IReadOnlyList<Recipe> GetAll()
        {
            lock (_lock)
            {
                return _recipes.ToList();
            }
        }

        public static Recipe? GetRandom()
        {
            lock (_lock)
            {
                if (_recipes.Count == 0) return null;
                var random = new Random();
                var index = random.Next(_recipes.Count);
                return _recipes[index];
            }
        }

        private static void TryLoadFromDisk()
        {
            try
            {
                if (!File.Exists(_dataFilePath))
                {
                    Directory.CreateDirectory(_dataDirectory);
                    return;
                }
                var json = File.ReadAllText(_dataFilePath);
                var list = JsonSerializer.Deserialize<List<Recipe>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (list != null)
                {
                    _recipes.Clear();
                    _recipes.AddRange(list);
                }
            }
            catch
            {
                // Em caso de erro de leitura/desserialização, inicia vazio
            }
        }

        private static void TrySaveToDisk()
        {
            try
            {
                Directory.CreateDirectory(_dataDirectory);
                var json = JsonSerializer.Serialize(_recipes, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(_dataFilePath, json);
            }
            catch
            {
                // Silencia falhas de escrita para não interromper o uso do app
            }
        }
    }
}


