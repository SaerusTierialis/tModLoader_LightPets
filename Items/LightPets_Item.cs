using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LightPets.Items
{
    //class names of buffs, items, and projectiles must all match

    /* ~~~~~~~~~~~~~~~~~~~~ Majora ~~~~~~~~~~~~~~~~~~~~ */
    class Majora : LanternSpirit
    {
        public Majora()
        {
            name = "Majora's Mask";
            toolTip = "You’ve met with a terrible fate, haven’t you?";
            width = 44;
            height = 40;
        }

        public override void AddRecipes()
        {
            //BrainMask
            Recipe recipe = CreateRecipe(1)
                .AddIngredient(ItemID.KingSlimeMask)
                .AddIngredient(ItemID.EyeMask)
                .AddIngredient(ItemID.BrainMask)
                .AddIngredient(ItemID.BeeMask)
                .AddIngredient(ItemID.SkeletronMask)
                .AddIngredient(ItemID.FleshMask)
                .AddIngredient(ItemID.DestroyerMask)
                .AddIngredient(ItemID.TwinMask)
                .AddIngredient(ItemID.SkeletronPrimeMask)
                .AddIngredient(ItemID.PlanteraMask)
                .AddIngredient(ItemID.GolemMask)
                .AddIngredient(ItemID.DukeFishronMask)
                .AddTile(TileID.WorkBenches)
                .Register();

            //EaterMask
            recipe = CreateRecipe(1)
                .AddIngredient(ItemID.KingSlimeMask)
                .AddIngredient(ItemID.EyeMask)
                .AddIngredient(ItemID.EaterMask)
                .AddIngredient(ItemID.BeeMask)
                .AddIngredient(ItemID.SkeletronMask)
                .AddIngredient(ItemID.FleshMask)
                .AddIngredient(ItemID.DestroyerMask)
                .AddIngredient(ItemID.TwinMask)
                .AddIngredient(ItemID.SkeletronPrimeMask)
                .AddIngredient(ItemID.PlanteraMask)
                .AddIngredient(ItemID.GolemMask)
                .AddIngredient(ItemID.DukeFishronMask)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }

    /* ~~~~~~~~~~~~~~~~~~~~ Vortex ~~~~~~~~~~~~~~~~~~~~ */
    class Vortex : LanternSpirit
    {
        public Vortex()
        {
            name = "Cog Vortex";
            toolTip = "Summons a Cog Vortex to help you navigate";
            width = 32;
            height = 32;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1)
                .AddIngredient(ItemID.Cog,100)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }

    /* ~~~~~~~~~~~~~~~~~~~~ Template & LanternSpirit ~~~~~~~~~~~~~~~~~~~~ */
    //note that abstract ModItem cause issues
    class LanternSpirit : ModItem
    {
        public string name = "Lantern Spirit";
        public string toolTip = "Summons a Lantern Spirit to help you navigate";
        public int width = 43;
        public int height = 40;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(name);
            Tooltip.SetDefault(toolTip);
        }
        public override void SetDefaults()
        {
            //specific
            Item.width = width;
            Item.height = height;
            //generic
            Item.damage = 0;
            Item.useStyle = 1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.rare = 11;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.shoot = Mod.Find<ModProjectile>(GetType().Name).Type;
            Item.buffType = Mod.Find<ModBuff>(GetType().Name).Type;
            Item.UseSound = SoundID.Item4;
        }

        public override void AddRecipes()
        {
            if (name == "Lantern Spirit")
            {
                Recipe recipe = CreateRecipe(1)
                    .AddIngredient(ItemID.CagedLantern)
                    .AddIngredient(ItemID.CarriageLantern)
                    .AddIngredient(ItemID.ObsidianLantern)
                    .AddIngredient(ItemID.Robe, 1)
                    .AddTile(TileID.WorkBenches)
                    .Register();
            }
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            //start the pet buff
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}
