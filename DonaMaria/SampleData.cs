using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace DonaMaria
{
    public static class SampleData
    {
        public static void LoadSampleData()
        {
            LoadSampleKitchenTypes();
            LoadSampleIngredients();
            LoadSampleRecipes();
        }

        public static void LoadSampleIngredientsOnly()
        {
            LoadSampleIngredients();
        }

        private static void LoadSampleKitchenTypes()
        {
            var kitchenTypes = new List<KitchenType>
            {
                new KitchenType { Codigo = "BR", Nome = "Brasileira", Descricao = "Culinária tradicional brasileira com influências indígenas, africanas e europeias" },
                new KitchenType { Codigo = "IT", Nome = "Italiana", Descricao = "Culinária tradicional italiana conhecida por massas, pizzas e risottos" },
                new KitchenType { Codigo = "JP", Nome = "Japonesa", Descricao = "Culinária tradicional japonesa com foco em frescor e apresentação" },
                new KitchenType { Codigo = "MX", Nome = "Mexicana", Descricao = "Culinária tradicional mexicana com temperos vibrantes e cores intensas" },
                new KitchenType { Codigo = "FR", Nome = "Francesa", Descricao = "Culinária francesa clássica conhecida por suas técnicas refinadas" },
                new KitchenType { Codigo = "IN", Nome = "Indiana", Descricao = "Culinária indiana rica em especiarias e sabores complexos" },
                new KitchenType { Codigo = "TH", Nome = "Tailandesa", Descricao = "Culinária tailandesa com equilíbrio entre doce, salgado, ácido e picante" },
                new KitchenType { Codigo = "CH", Nome = "Chinesa", Descricao = "Culinária chinesa diversificada com técnicas de wok e dim sum" },
                new KitchenType { Codigo = "AR", Nome = "Árabe", Descricao = "Culinária árabe com especiarias do Oriente Médio e Norte da África" },
                new KitchenType { Codigo = "GR", Nome = "Grega", Descricao = "Culinária grega mediterrânea com azeite, ervas e ingredientes frescos" }
            };

            KitchenTypeManager.SetKitchenTypes(kitchenTypes);
        }

        private static void LoadSampleIngredients()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Codigo = "ING001", Nome = "Azeite de Oliva", Descricao = "Azeite extra virgem para temperos e frituras" },
                new Ingredient { Codigo = "ING002", Nome = "Sal", Descricao = "Sal refinado para temperar alimentos" },
                new Ingredient { Codigo = "ING003", Nome = "Pimenta do Reino", Descricao = "Pimenta preta moída para temperar" },
                new Ingredient { Codigo = "ING004", Nome = "Alho", Descricao = "Dente de alho fresco para temperos" },
                new Ingredient { Codigo = "ING005", Nome = "Cebola", Descricao = "Cebola branca ou roxa para refogados" },
                new Ingredient { Codigo = "ING006", Nome = "Tomate", Descricao = "Tomate maduro para molhos e saladas" },
                new Ingredient { Codigo = "ING007", Nome = "Cenoura", Descricao = "Cenoura fresca para sopas e refogados" },
                new Ingredient { Codigo = "ING008", Nome = "Batata", Descricao = "Batata inglesa para cozidos e frituras" },
                new Ingredient { Codigo = "ING009", Nome = "Arroz", Descricao = "Arroz branco tipo 1 para acompanhamentos" },
                new Ingredient { Codigo = "ING010", Nome = "Feijão", Descricao = "Feijão preto ou carioca para feijoada" },
                new Ingredient { Codigo = "ING011", Nome = "Carne Bovina", Descricao = "Carne bovina para assados e refogados" },
                new Ingredient { Codigo = "ING012", Nome = "Frango", Descricao = "Peito ou coxa de frango para grelhados" },
                new Ingredient { Codigo = "ING013", Nome = "Peixe", Descricao = "Peixe fresco para grelhados e ensopados" },
                new Ingredient { Codigo = "ING014", Nome = "Queijo", Descricao = "Queijo ralado ou em fatias para gratinados" },
                new Ingredient { Codigo = "ING015", Nome = "Leite", Descricao = "Leite integral para molhos e sobremesas" },
                new Ingredient { Codigo = "ING016", Nome = "Ovos", Descricao = "Ovos frescos para frituras e massas" },
                new Ingredient { Codigo = "ING017", Nome = "Farinha de Trigo", Descricao = "Farinha de trigo para massas e bolos" },
                new Ingredient { Codigo = "ING018", Nome = "Açúcar", Descricao = "Açúcar cristal para doces e sobremesas" },
                new Ingredient { Codigo = "ING019", Nome = "Vinagre", Descricao = "Vinagre branco ou balsâmico para temperos" },
                new Ingredient { Codigo = "ING020", Nome = "Limão", Descricao = "Limão fresco para temperos e sucos" }
            };

            foreach (var ingredient in ingredients)
            {
                IngredientRepository.AddOrUpdate(ingredient);
            }
        }

        private static void LoadSampleRecipes()
        {
            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Codigo = "FEI001",
                    Nome = "Feijoada Completa",
                    TipoCozinha = "Brasileira",
                    TempoPreparoMinutos = 180,
                    Porcoes = 8,
                    ModoPreparo = "1. Deixe o feijão de molho por 12 horas.\n2. Em uma panela de pressão, cozinhe o feijão com água e sal por 30 minutos.\n3. Em outra panela, refogue a cebola e o alho.\n4. Adicione as carnes e deixe dourar.\n5. Junte o feijão cozido e deixe ferver por 15 minutos.\n6. Ajuste o sal e sirva com arroz, couve e farofa.",
                    Utensilios = "Panela de pressão, panela grande, colher de pau",
                    Observacoes = "Tradicional prato brasileiro, perfeito para o almoço de domingo",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Feijão preto", Quantidade = "500g", Observacao = "Deixar de molho" },
                        new IngredientItem { Nome = "Linguiça calabresa", Quantidade = "300g", Observacao = "Cortada em rodelas" },
                        new IngredientItem { Nome = "Costela de porco", Quantidade = "400g", Observacao = "Em pedaços" },
                        new IngredientItem { Nome = "Bacon", Quantidade = "200g", Observacao = "Em cubos" },
                        new IngredientItem { Nome = "Cebola", Quantidade = "2 unidades", Observacao = "Picada" },
                        new IngredientItem { Nome = "Alho", Quantidade = "4 dentes", Observacao = "Amassados" },
                        new IngredientItem { Nome = "Sal", Quantidade = "A gosto", Observacao = "" },
                        new IngredientItem { Nome = "Pimenta do reino", Quantidade = "1 colher de chá", Observacao = "" }
                    }
                },
                new Recipe
                {
                    Codigo = "SPA001",
                    Nome = "Spaghetti Carbonara",
                    TipoCozinha = "Italiana",
                    TempoPreparoMinutos = 25,
                    Porcoes = 4,
                    ModoPreparo = "1. Cozinhe o spaghetti em água salgada até ficar al dente.\n2. Em uma frigideira, frite o bacon até ficar crocante.\n3. Bata os ovos com o queijo parmesão e pimenta.\n4. Escorra o macarrão e misture com o bacon.\n5. Retire do fogo e misture rapidamente com os ovos.\n6. Sirva imediatamente com mais parmesão por cima.",
                    Utensilios = "Panela grande, frigideira, batedor",
                    Observacoes = "Não cozinhe os ovos, apenas misture rapidamente para criar o creme",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Spaghetti", Quantidade = "400g", Observacao = "" },
                        new IngredientItem { Nome = "Bacon", Quantidade = "200g", Observacao = "Em cubos pequenos" },
                        new IngredientItem { Nome = "Ovos", Quantidade = "4 unidades", Observacao = "Grandes" },
                        new IngredientItem { Nome = "Queijo parmesão", Quantidade = "100g", Observacao = "Ralado" },
                        new IngredientItem { Nome = "Pimenta do reino", Quantidade = "A gosto", Observacao = "Moída na hora" },
                        new IngredientItem { Nome = "Sal", Quantidade = "A gosto", Observacao = "" }
                    }
                },
                new Recipe
                {
                    Codigo = "SUS001",
                    Nome = "Sushi de Salmão",
                    TipoCozinha = "Japonesa",
                    TempoPreparoMinutos = 60,
                    Porcoes = 4,
                    ModoPreparo = "1. Lave o arroz até a água ficar clara.\n2. Cozinhe o arroz com água e vinagre de arroz.\n3. Deixe esfriar completamente.\n4. Corte o salmão em tiras finas.\n5. Molde o arroz em bolinhas pequenas.\n6. Coloque uma fatia de salmão sobre cada bolinha.\n7. Sirva com wasabi, gengibre e molho shoyu.",
                    Utensilios = "Panela, faca afiada, tigela, luvas para sushi",
                    Observacoes = "Use salmão fresco de qualidade sashimi",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Arroz japonês", Quantidade = "2 xícaras", Observacao = "Grão curto" },
                        new IngredientItem { Nome = "Salmão fresco", Quantidade = "300g", Observacao = "Corte sashimi" },
                        new IngredientItem { Nome = "Vinagre de arroz", Quantidade = "3 colheres de sopa", Observacao = "" },
                        new IngredientItem { Nome = "Açúcar", Quantidade = "1 colher de sopa", Observacao = "" },
                        new IngredientItem { Nome = "Sal", Quantidade = "1 colher de chá", Observacao = "" },
                        new IngredientItem { Nome = "Wasabi", Quantidade = "A gosto", Observacao = "Pasta" },
                        new IngredientItem { Nome = "Gengibre em conserva", Quantidade = "50g", Observacao = "Fatiado" }
                    }
                },
                new Recipe
                {
                    Codigo = "TAC001",
                    Nome = "Tacos de Carne",
                    TipoCozinha = "Mexicana",
                    TempoPreparoMinutos = 45,
                    Porcoes = 6,
                    ModoPreparo = "1. Tempere a carne com cominho, páprica e sal.\n2. Refogue a cebola até ficar transparente.\n3. Adicione a carne e cozinhe até dourar.\n4. Adicione o tomate picado e deixe cozinhar.\n5. Aqueça as tortilhas.\n6. Monte os tacos com a carne, alface, tomate e queijo.\n7. Sirva com molho de pimenta e limão.",
                    Utensilios = "Frigideira grande, tábua de corte, faca",
                    Observacoes = "Use carne moída magra para um resultado mais saudável",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Carne moída", Quantidade = "500g", Observacao = "Magra" },
                        new IngredientItem { Nome = "Tortilhas de milho", Quantidade = "12 unidades", Observacao = "Pequenas" },
                        new IngredientItem { Nome = "Cebola", Quantidade = "1 unidade", Observacao = "Picada" },
                        new IngredientItem { Nome = "Tomate", Quantidade = "2 unidades", Observacao = "Picado" },
                        new IngredientItem { Nome = "Alface", Quantidade = "1 unidade", Observacao = "Picada" },
                        new IngredientItem { Nome = "Queijo cheddar", Quantidade = "150g", Observacao = "Ralado" },
                        new IngredientItem { Nome = "Cominho", Quantidade = "1 colher de chá", Observacao = "Em pó" },
                        new IngredientItem { Nome = "Páprica", Quantidade = "1 colher de chá", Observacao = "Doce" }
                    }
                },
                new Recipe
                {
                    Codigo = "RAT001",
                    Nome = "Ratatouille",
                    TipoCozinha = "Francesa",
                    TempoPreparoMinutos = 90,
                    Porcoes = 6,
                    ModoPreparo = "1. Corte todos os vegetais em rodelas finas.\n2. Refogue a cebola e o alho até ficarem macios.\n3. Adicione o tomate e deixe cozinhar até formar molho.\n4. Em uma assadeira, arrume as rodelas de vegetais alternadamente.\n5. Regue com azeite e tempere com ervas.\n6. Asse em forno a 180°C por 45 minutos.\n7. Sirva quente ou frio.",
                    Utensilios = "Assadeira, frigideira, faca afiada, mandolina (opcional)",
                    Observacoes = "Prato vegetariano clássico da Provença",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Berinjela", Quantidade = "2 unidades", Observacao = "Médias" },
                        new IngredientItem { Nome = "Abobrinha", Quantidade = "2 unidades", Observacao = "Médias" },
                        new IngredientItem { Nome = "Tomate", Quantidade = "4 unidades", Observacao = "Maduros" },
                        new IngredientItem { Nome = "Pimentão vermelho", Quantidade = "1 unidade", Observacao = "Grande" },
                        new IngredientItem { Nome = "Cebola", Quantidade = "1 unidade", Observacao = "Média" },
                        new IngredientItem { Nome = "Alho", Quantidade = "3 dentes", Observacao = "Amassados" },
                        new IngredientItem { Nome = "Azeite de oliva", Quantidade = "4 colheres de sopa", Observacao = "Extra virgem" },
                        new IngredientItem { Nome = "Manjericão", Quantidade = "1 ramo", Observacao = "Fresco" },
                        new IngredientItem { Nome = "Tomilho", Quantidade = "1 ramo", Observacao = "Fresco" }
                    }
                },
                new Recipe
                {
                    Codigo = "CUR001",
                    Nome = "Curry de Frango",
                    TipoCozinha = "Indiana",
                    TempoPreparoMinutos = 50,
                    Porcoes = 4,
                    ModoPreparo = "1. Corte o frango em cubos e tempere com sal e pimenta.\n2. Refogue a cebola até ficar dourada.\n3. Adicione o alho, gengibre e especiarias.\n4. Junte o frango e deixe dourar.\n5. Adicione o tomate e o leite de coco.\n6. Deixe cozinhar em fogo baixo por 30 minutos.\n7. Ajuste o sal e sirva com arroz basmati.",
                    Utensilios = "Panela grande, colher de pau, tigela",
                    Observacoes = "Ajuste o nível de pimenta conforme sua preferência",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Peito de frango", Quantidade = "600g", Observacao = "Sem pele, em cubos" },
                        new IngredientItem { Nome = "Cebola", Quantidade = "2 unidades", Observacao = "Médias, picadas" },
                        new IngredientItem { Nome = "Alho", Quantidade = "4 dentes", Observacao = "Amassados" },
                        new IngredientItem { Nome = "Gengibre", Quantidade = "2 colheres de chá", Observacao = "Ralado" },
                        new IngredientItem { Nome = "Tomate", Quantidade = "3 unidades", Observacao = "Picados" },
                        new IngredientItem { Nome = "Leite de coco", Quantidade = "400ml", Observacao = "" },
                        new IngredientItem { Nome = "Curry em pó", Quantidade = "2 colheres de sopa", Observacao = "" },
                        new IngredientItem { Nome = "Cominho", Quantidade = "1 colher de chá", Observacao = "Em pó" },
                        new IngredientItem { Nome = "Coentro", Quantidade = "1 colher de chá", Observacao = "Em pó" },
                        new IngredientItem { Nome = "Pimenta caiena", Quantidade = "1/2 colher de chá", Observacao = "Ou a gosto" }
                    }
                },
                new Recipe
                {
                    Codigo = "PAD001",
                    Nome = "Pad Thai",
                    TipoCozinha = "Tailandesa",
                    TempoPreparoMinutos = 30,
                    Porcoes = 4,
                    ModoPreparo = "1. Deixe o macarrão de molho em água morna por 10 minutos.\n2. Aqueça o óleo em uma frigideira grande.\n3. Frite o camarão até ficar rosado.\n4. Adicione o alho e o pimentão.\n5. Junte o macarrão e os brotos de feijão.\n6. Adicione o molho de peixe, açúcar e suco de limão.\n7. Misture bem e sirva com amendoim e coentro.",
                    Utensilios = "Frigideira grande, colher de pau, tigela",
                    Observacoes = "Prato nacional da Tailândia, equilibra todos os sabores",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Macarrão de arroz", Quantidade = "300g", Observacao = "Largos" },
                        new IngredientItem { Nome = "Camarão", Quantidade = "300g", Observacao = "Médios, descascados" },
                        new IngredientItem { Nome = "Brotos de feijão", Quantidade = "200g", Observacao = "Frescos" },
                        new IngredientItem { Nome = "Pimentão vermelho", Quantidade = "1 unidade", Observacao = "Em tiras" },
                        new IngredientItem { Nome = "Alho", Quantidade = "3 dentes", Observacao = "Picados" },
                        new IngredientItem { Nome = "Ovo", Quantidade = "2 unidades", Observacao = "Batom" },
                        new IngredientItem { Nome = "Molho de peixe", Quantidade = "3 colheres de sopa", Observacao = "" },
                        new IngredientItem { Nome = "Açúcar mascavo", Quantidade = "2 colheres de sopa", Observacao = "" },
                        new IngredientItem { Nome = "Suco de limão", Quantidade = "2 colheres de sopa", Observacao = "Fresco" },
                        new IngredientItem { Nome = "Amendoim", Quantidade = "50g", Observacao = "Triturado" }
                    }
                },
                new Recipe
                {
                    Codigo = "DIM001",
                    Nome = "Dim Sum de Porco",
                    TipoCozinha = "Chinesa",
                    TempoPreparoMinutos = 120,
                    Porcoes = 6,
                    ModoPreparo = "1. Misture a carne de porco com os temperos.\n2. Adicione o repolho e o gengibre.\n3. Coloque uma colher da mistura em cada massa wonton.\n4. Feche formando pequenos pacotes.\n5. Cozinhe no vapor por 15 minutos.\n6. Sirva com molho de soja e vinagre.",
                    Utensilios = "Cuscuzeira ou vapor, tigela grande, colher",
                    Observacoes = "Tradicional dim sum chinês, perfeito para brunch",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Carne de porco moída", Quantidade = "400g", Observacao = "Magra" },
                        new IngredientItem { Nome = "Repolho", Quantidade = "200g", Observacao = "Picado fino" },
                        new IngredientItem { Nome = "Gengibre", Quantidade = "2 colheres de chá", Observacao = "Ralado" },
                        new IngredientItem { Nome = "Alho", Quantidade = "3 dentes", Observacao = "Amassados" },
                        new IngredientItem { Nome = "Cebolinha", Quantidade = "3 unidades", Observacao = "Picadas" },
                        new IngredientItem { Nome = "Massa wonton", Quantidade = "30 unidades", Observacao = "Quadradas" },
                        new IngredientItem { Nome = "Molho de soja", Quantidade = "2 colheres de sopa", Observacao = "Claro" },
                        new IngredientItem { Nome = "Açúcar", Quantidade = "1 colher de chá", Observacao = "" },
                        new IngredientItem { Nome = "Óleo de gergelim", Quantidade = "1 colher de chá", Observacao = "" }
                    }
                },
                new Recipe
                {
                    Codigo = "HUM001",
                    Nome = "Hummus Tradicional",
                    TipoCozinha = "Árabe",
                    TempoPreparoMinutos = 20,
                    Porcoes = 6,
                    ModoPreparo = "1. Deixe o grão-de-bico de molho por 8 horas.\n2. Cozinhe até ficar macio.\n3. No processador, bata o grão-de-bico com tahine.\n4. Adicione o alho, limão e azeite.\n5. Bata até formar uma pasta lisa.\n6. Ajuste o sal e sirva com pão pita.",
                    Utensilios = "Processador de alimentos, panela, tigela",
                    Observacoes = "Pasta tradicional do Oriente Médio, rica em proteínas",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Grão-de-bico", Quantidade = "300g", Observacao = "Seco, deixar de molho" },
                        new IngredientItem { Nome = "Tahine", Quantidade = "3 colheres de sopa", Observacao = "Pasta de gergelim" },
                        new IngredientItem { Nome = "Alho", Quantidade = "3 dentes", Observacao = "Amassados" },
                        new IngredientItem { Nome = "Suco de limão", Quantidade = "3 colheres de sopa", Observacao = "Fresco" },
                        new IngredientItem { Nome = "Azeite de oliva", Quantidade = "4 colheres de sopa", Observacao = "Extra virgem" },
                        new IngredientItem { Nome = "Cominho", Quantidade = "1 colher de chá", Observacao = "Em pó" },
                        new IngredientItem { Nome = "Sal", Quantidade = "A gosto", Observacao = "" },
                        new IngredientItem { Nome = "Pimenta do reino", Quantidade = "A gosto", Observacao = "" }
                    }
                },
                new Recipe
                {
                    Codigo = "MOU001",
                    Nome = "Moussaka",
                    TipoCozinha = "Grega",
                    TempoPreparoMinutos = 120,
                    Porcoes = 8,
                    ModoPreparo = "1. Corte a berinjela em fatias e salgue.\n2. Frite as fatias até dourarem.\n3. Refogue a carne com cebola e tomate.\n4. Em uma assadeira, alterne camadas de berinjela e carne.\n5. Faça o molho bechamel com queijo.\n6. Cubra a moussaka com o molho.\n7. Asse em forno a 180°C por 45 minutos.",
                    Utensilios = "Assadeira grande, frigideira, panela para molho",
                    Observacoes = "Prato tradicional grego, uma lasanha mediterrânea",
                    Ingredientes = new List<IngredientItem>
                    {
                        new IngredientItem { Nome = "Berinjela", Quantidade = "3 unidades", Observacao = "Grandes, em fatias" },
                        new IngredientItem { Nome = "Carne moída", Quantidade = "500g", Observacao = "Bovina" },
                        new IngredientItem { Nome = "Cebola", Quantidade = "2 unidades", Observacao = "Picadas" },
                        new IngredientItem { Nome = "Tomate", Quantidade = "3 unidades", Observacao = "Picados" },
                        new IngredientItem { Nome = "Queijo parmesão", Quantidade = "100g", Observacao = "Ralado" },
                        new IngredientItem { Nome = "Leite", Quantidade = "500ml", Observacao = "Integral" },
                        new IngredientItem { Nome = "Manteiga", Quantidade = "50g", Observacao = "" },
                        new IngredientItem { Nome = "Farinha de trigo", Quantidade = "3 colheres de sopa", Observacao = "" },
                        new IngredientItem { Nome = "Ovo", Quantidade = "2 unidades", Observacao = "Batom" },
                        new IngredientItem { Nome = "Noz-moscada", Quantidade = "1 pitada", Observacao = "Ralada" }
                    }
                }
            };

            foreach (var recipe in recipes)
            {
                RecipeRepository.AddOrUpdate(recipe);
            }
        }

        public static void CreateSampleImages()
        {
            // Este método criaria imagens de exemplo para as receitas
            // Por enquanto, apenas documentamos que as imagens seriam criadas aqui
            var imageDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DonaMaria", "Images");
            
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            // Aqui você poderia adicionar código para baixar ou criar imagens de exemplo
            // Por exemplo, usando APIs de imagens gratuitas ou criando imagens programaticamente
        }
    }
}
