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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.KingSlimeMask);
            recipe.AddIngredient(ItemID.EyeMask);
            recipe.AddIngredient(ItemID.BrainMask);
            recipe.AddIngredient(ItemID.BeeMask);
            recipe.AddIngredient(ItemID.SkeletronMask);
            recipe.AddIngredient(ItemID.FleshMask);
            recipe.AddIngredient(ItemID.DestroyerMask);
            recipe.AddIngredient(ItemID.TwinMask);
            recipe.AddIngredient(ItemID.SkeletronPrimeMask);
            recipe.AddIngredient(ItemID.PlanteraMask);
            recipe.AddIngredient(ItemID.GolemMask);
            recipe.AddIngredient(ItemID.DukeFishronMask);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            //EaterMask
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.KingSlimeMask);
            recipe.AddIngredient(ItemID.EyeMask);
            recipe.AddIngredient(ItemID.EaterMask);
            recipe.AddIngredient(ItemID.BeeMask);
            recipe.AddIngredient(ItemID.SkeletronMask);
            recipe.AddIngredient(ItemID.FleshMask);
            recipe.AddIngredient(ItemID.DestroyerMask);
            recipe.AddIngredient(ItemID.TwinMask);
            recipe.AddIngredient(ItemID.SkeletronPrimeMask);
            recipe.AddIngredient(ItemID.PlanteraMask);
            recipe.AddIngredient(ItemID.GolemMask);
            recipe.AddIngredient(ItemID.DukeFishronMask);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cog,100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
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
            item.width = width;
            item.height = height;
            //generic
            item.damage = 0;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.rare = 11;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.shoot = mod.ProjectileType(GetType().Name);
            item.buffType = mod.BuffType(GetType().Name);
            item.UseSound = SoundID.Item4;
        }

        public override void AddRecipes()
        {
            if (name == "Lantern Spirit")
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CagedLantern);
                recipe.AddIngredient(ItemID.CarriageLantern);
                recipe.AddIngredient(ItemID.ObsidianLantern);
                recipe.AddIngredient(ItemID.Robe, 1);
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
            }
        }

        public override void UseStyle(Player player)
        {
            //start the pet buff
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}
