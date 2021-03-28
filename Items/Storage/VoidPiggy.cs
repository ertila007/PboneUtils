﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PboneUtils.Items.Storage
{
    public class VoidPiggy : RightClickToggleItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            //item.Size = new Vector2(24, 16);
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateInventory(Player player)
        {
            base.UpdateInventory(player);
            player.GetModPlayer<PbonePlayer>().VoidPig = Enabled;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PiggyBank);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddIngredient(ItemID.JungleSpores, 5);
            recipe.AddRecipeGroup(PboneUtils.Recipes.AnyShadowScale, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
