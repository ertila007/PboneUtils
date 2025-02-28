﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace PboneUtils.Projectiles.Selection
{
    public class GreaterStaffOfRegrowthPro : SelectionProjectile
    {
        public override Action<int, int> TileAction => (i, j) => {
            Tile tile = Framing.GetTileSafely(i, j);
            if (Main.tileAlch[tile.type])
            {
                if (tile.type > 82)
                {
                    int type = tile.frameX / 18;
                    int herb = 313 + type;
                    int seed = 307 + type;
                    if (type == 6)
                    {
                        herb = 2358;
                        seed = 2357;
                    }

                    ModTile mTile = ModContent.GetModTile(tile.type);
                    if (mTile == null)
                    {
                        // Staff of regrowth herb effect
                        WorldGen.KillTile(i, j, noItem: true);
                        Item.NewItem(i * 16, j * 16, 16, 16, seed, WorldGen.genRand.Next(1, 6));
                        Item.NewItem(i * 16, j * 16, 16, 16, herb, WorldGen.genRand.Next(1, 3));

                        // Replant
                        Item seedItem = new Item();
                        seedItem.SetDefaults(seed);
                        WorldGen.PlaceTile(i, j, seedItem.createTile, style: seedItem.placeStyle);
                    }
                    else
                    {
                        WorldGen.KillTile(i, j); // Kill it with items for mod items, because I can't account for them
                    }
                }
            }
        };
    }
}
