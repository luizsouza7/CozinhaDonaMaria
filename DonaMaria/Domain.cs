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

    public class KitchenType
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    public class Ingredient
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    public static class KitchenTypeManager
    {
        private static readonly object _lock = new object();
        private static readonly List<KitchenType> _kitchenTypes = new List<KitchenType>();
        private static readonly string _dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DonaMaria");
        private static readonly string _kitchenTypesFilePath = Path.Combine(_dataDirectory, "kitchen_types.json");

        static KitchenTypeManager()
        {
            TryLoadFromDisk();
            // Se não há tipos salvos, inicializa com os padrão
            if (_kitchenTypes.Count == 0)
            {
                SetDefaultKitchenTypes();
            }
        }

        public static void SetKitchenTypes(List<KitchenType> kitchenTypes)
        {
            if (kitchenTypes == null) throw new ArgumentNullException(nameof(kitchenTypes));
            lock (_lock)
            {
                _kitchenTypes.Clear();
                _kitchenTypes.AddRange(kitchenTypes.Where(kt => !string.IsNullOrWhiteSpace(kt.Nome)));
                TrySaveToDisk();
            }
        }

        public static void AddKitchenType(KitchenType kitchenType)
        {
            if (kitchenType == null || string.IsNullOrWhiteSpace(kitchenType.Nome)) return;
            lock (_lock)
            {
                if (!_kitchenTypes.Any(kt => string.Equals(kt.Nome, kitchenType.Nome, StringComparison.OrdinalIgnoreCase)))
                {
                    _kitchenTypes.Add(kitchenType);
                    TrySaveToDisk();
                }
            }
        }

        public static void RemoveKitchenType(string kitchenTypeName)
        {
            if (string.IsNullOrWhiteSpace(kitchenTypeName)) return;
            lock (_lock)
            {
                _kitchenTypes.RemoveAll(kt => string.Equals(kt.Nome, kitchenTypeName, StringComparison.OrdinalIgnoreCase));
                TrySaveToDisk();
            }
        }

        public static IReadOnlyList<KitchenType> GetKitchenTypes()
        {
            lock (_lock)
            {
                return _kitchenTypes.ToList();
            }
        }

        public static IReadOnlyList<string> GetKitchenTypeNames()
        {
            lock (_lock)
            {
                return _kitchenTypes.Select(kt => kt.Nome).ToList();
            }
        }

        /// <summary>
        /// Método para definir rapidamente os tipos de cozinha desejados.
        /// Use este método para configurar quais tipos de cozinha aparecerão no cadastro de receitas.
        /// </summary>
        /// <param name="kitchenTypes">Lista dos tipos de cozinha que devem aparecer no sistema</param>
        public static void ConfigureKitchenTypes(params string[] kitchenTypes)
        {
            if (kitchenTypes == null || kitchenTypes.Length == 0)
            {
                SetDefaultKitchenTypes();
                return;
            }

            var validTypes = kitchenTypes.Where(kt => !string.IsNullOrWhiteSpace(kt))
                .Select(kt => new KitchenType { Nome = kt, Codigo = "", Descricao = "" })
                .ToList();
            SetKitchenTypes(validTypes);
        }

        private static void SetDefaultKitchenTypes()
        {
            _kitchenTypes.AddRange(new[] 
            { 
                new KitchenType { Codigo = "BR", Nome = "Brasileira", Descricao = "Culinária tradicional brasileira" },
                new KitchenType { Codigo = "IT", Nome = "Italiana", Descricao = "Culinária tradicional italiana" },
                new KitchenType { Codigo = "JP", Nome = "Japonesa", Descricao = "Culinária tradicional japonesa" },
                new KitchenType { Codigo = "MX", Nome = "Mexicana", Descricao = "Culinária tradicional mexicana" }
            });
            TrySaveToDisk();
        }

        private static void TryLoadFromDisk()
        {
            try
            {
                if (!File.Exists(_kitchenTypesFilePath))
                {
                    Directory.CreateDirectory(_dataDirectory);
                    return;
                }
                var json = File.ReadAllText(_kitchenTypesFilePath);
                var list = JsonSerializer.Deserialize<List<KitchenType>>(json);
                if (list != null)
                {
                    _kitchenTypes.Clear();
                    _kitchenTypes.AddRange(list.Where(kt => !string.IsNullOrWhiteSpace(kt.Nome)));
                }
            }
            catch
            {
                // Em caso de erro, mantém lista vazia
            }
        }

        private static void TrySaveToDisk()
        {
            try
            {
                Directory.CreateDirectory(_dataDirectory);
                var json = JsonSerializer.Serialize(_kitchenTypes, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(_kitchenTypesFilePath, json);
            }
            catch
            {
                // Silencia falhas de escrita
            }
        }
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

        public static bool Remove(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return false;
            lock (_lock)
            {
                var removed = _recipes.RemoveAll(r => string.Equals(r.Codigo, codigo, StringComparison.OrdinalIgnoreCase)) > 0;
                if (removed)
                {
                    TrySaveToDisk();
                }
                return removed;
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

    public static class IngredientRepository
    {
        private static readonly object _lock = new object();
        private static readonly List<Ingredient> _ingredients = new List<Ingredient>();
        private static readonly string _dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DonaMaria");
        private static readonly string _dataFilePath = Path.Combine(_dataDirectory, "ingredients.json");

        static IngredientRepository()
        {
            TryLoadFromDisk();
        }

        public static void AddOrUpdate(Ingredient ingredient)
        {
            if (ingredient == null) throw new ArgumentNullException(nameof(ingredient));
            lock (_lock)
            {
                var existing = _ingredients.FirstOrDefault(i => string.Equals(i.Codigo, ingredient.Codigo, StringComparison.OrdinalIgnoreCase));
                if (existing == null)
                {
                    _ingredients.Add(ingredient);
                }
                else
                {
                    // Atualiza campos
                    existing.Nome = ingredient.Nome;
                    existing.Descricao = ingredient.Descricao;
                }
                TrySaveToDisk();
            }
        }

        public static IReadOnlyList<Ingredient> GetAll()
        {
            lock (_lock)
            {
                return _ingredients.ToList();
            }
        }

        public static bool Remove(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return false;
            lock (_lock)
            {
                var removed = _ingredients.RemoveAll(i => string.Equals(i.Codigo, codigo, StringComparison.OrdinalIgnoreCase)) > 0;
                if (removed)
                {
                    TrySaveToDisk();
                }
                return removed;
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
                var list = JsonSerializer.Deserialize<List<Ingredient>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (list != null)
                {
                    _ingredients.Clear();
                    _ingredients.AddRange(list);
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
                var json = JsonSerializer.Serialize(_ingredients, new JsonSerializerOptions
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


