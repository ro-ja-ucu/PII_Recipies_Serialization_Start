//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Recipies
{
    public class Recipe : IJsonConvertible
    {
        // private ArrayList steps = new ArrayList();
        public Product FinalProduct { get; set; }

        [JsonInclude]
        public ArrayList Steps { get; private set; } = new ArrayList();

        public void AddStep(Step step)
        {
            this.Steps.Add(step);
        }

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public void LoadFromJson(string json)
        {
            Recipe recipe = JsonSerializer.Deserialize<Recipe>(json);
            this.FinalProduct = recipe.FinalProduct;
            this.Steps = recipe.Steps;
        }

        public void RemoveStep(Step step)
        {
            this.Steps.Remove(step);
        }
    }
}