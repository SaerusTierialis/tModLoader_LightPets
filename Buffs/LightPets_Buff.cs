using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace LightPets.Buffs
{
    //class names of buffs, items, and projectiles must all match

    /* ~~~~~~~~~~~~~~~~~~~~ Majora ~~~~~~~~~~~~~~~~~~~~ */
    public class Majora : LanternSpirit
    {
        public Majora()
        {
            name = "Majora's Mask";
            tooltip = "You've met with a terrible fate, haven't you?";
        }
    }

    /* ~~~~~~~~~~~~~~~~~~~~ Vortex ~~~~~~~~~~~~~~~~~~~~ */
    public class Vortex : LanternSpirit
    {
        public Vortex()
        {
            name = "Cog Vortex";
            tooltip = "Summons a Cog Vortex to help you navigate";
        }
    }

    /* ~~~~~~~~~~~~~~~~~~~~ Template & LanternSpirit ~~~~~~~~~~~~~~~~~~~~ */
    //note that abstract ModBuff cause issues
    public class LanternSpirit : ModBuff
    {
        public string name = "Lantern Spirit";
        public string tooltip = "Summons a Lantern Spirit to help you navigate";

        public override void SetStaticDefaults()
        {
            //specific
            DisplayName.SetDefault(name);
            Description.SetDefault(tooltip);
            //generic
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //make pet, add buff time, set findTreasure
            MyPlayer myPlayer = player.GetModPlayer<MyPlayer>();
            myPlayer.currentLightPet = GetType().Name;
            if (myPlayer.reveal) player.findTreasure = true;
            player.buffTime[buffIndex] = 18000;
            int projID = Mod.Find<ModProjectile>(GetType().Name).Type;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[projID] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position + new Vector2(0, player.height / 2), new Vector2(), projID, 0, 0f, player.whoAmI);
            }
        }
    }
}