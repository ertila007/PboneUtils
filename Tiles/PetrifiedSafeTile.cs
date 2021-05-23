﻿using Terraria.ObjectData;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.ID;
using PboneUtils.Items.Storage;
using Terraria.Localization;
using System;

namespace PboneUtils.Tiles
{
    [Obsolete("Petrified Safe is now crafted.")]
    public class PetrifiedSafeTile : ModTile
    {
        public static bool MessageSent = false;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(1, 3);
            TileObjectData.newTile.CoordinateHeights = new int[4] {
                16,
                16,
                16,
                16
            };
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            AddMapEntry(Color.DarkGray, name);
            dustType = DustID.Stone;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            base.KillTile(i, j, ref fail, ref effectOnly, ref noItem);
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.type == Type)
            {
                fail = !NPC.downedBoss3;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (PboneUtilsConfig.Instance.StorageItemsToggle)
                Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<PetrifiedSafe>());
            else if (!MessageSent)
            {
                Main.NewText(Language.GetTextValue("Mods.PboneUtils.Message.PetrifiedSafeDisabled1"), Main.OurFavoriteColor);
                Main.NewText(Language.GetTextValue("Mods.PboneUtils.Message.PetrifiedSafeDisabled2"), Main.OurFavoriteColor);
                MessageSent = true;
            }
        }
    }
}
