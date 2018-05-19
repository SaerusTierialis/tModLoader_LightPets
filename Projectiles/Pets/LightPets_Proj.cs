using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LightPets.Projectiles.Pets
{
    //class names of buffs, items, and projectiles must all match

    /* ~~~~~~~~~~~~~~~~~~~~ Majora ~~~~~~~~~~~~~~~~~~~~ */
    public class Majora : LightPetProj
    {
        public Majora()
        {
            name = "Majora's Mask";
            width = 44;
            height = 40;
        }
    }

    /* ~~~~~~~~~~~~~~~~~~~~ Vortex ~~~~~~~~~~~~~~~~~~~~ */
    public class Vortex : LightPetProj
    {
        public Vortex()
        {
            name = "Cog Vortex";
            width = 32;
            height = 32;
            rotate = true;
            rotateVal = 1f;
        }
    }

    /* ~~~~~~~~~~~~~~~~~~~~ LanternSpirit ~~~~~~~~~~~~~~~~~~~~ */
    public class LanternSpirit : LightPetProj
    {
        public LanternSpirit()
        {
            name = "Lantern Spirit";
            width = 43;
            height = 40;
        }
    }

    /* ~~~~~~~~~~~~~~~~~~~~ TEMPLATE ~~~~~~~~~~~~~~~~~~~~ */
    public abstract class LightPetProj : ModProjectile
    {
        public bool rotate = false;
        public float rotateVal = 0;
        public string name = "";
        public int width = 0;
        public int height = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(name);
        }
        public override void SetDefaults()
        {
            //specific
            projectile.width = width;
            projectile.height = height;
            //generic
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.light = 1.5f;
            projectile.tileCollide = false;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.LightPet[projectile.type] = true;
            Main.projPet[projectile.type] = true;
        }

        public override void AI()
        {
            //maintain
            Player player = Main.player[projectile.owner];
            MyPlayer myPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (!player.active)
            {
                projectile.active = false;
                return;
            }
            if (player.dead)
            {
                myPlayer.currentLightPet = "";
            }
            if (myPlayer.currentLightPet == this.GetType().Name)
            {
                projectile.timeLeft = 2;
            }

            //move
            projectile.direction = player.direction;

            float target_x;
            if (player.direction == -1) target_x = player.Center.X - (projectile.width * 2);
            else target_x = player.Center.X + projectile.width;
            float target_y = player.position.Y - projectile.height;

            float dist_x = target_x - projectile.position.X;
            float dist_y = target_y - projectile.position.Y;

            if (Math.Abs(dist_x) > 1) projectile.velocity.X = dist_x / 20f;
            else projectile.velocity.X = 0;
            if (Math.Abs(dist_y) > 1) projectile.velocity.Y = dist_y / 20f;
            else projectile.velocity.Y = 0;

            //tilt or rotate (rotate=true && projectile.rotation=0 prevents this)
            if (!rotate) projectile.rotation = projectile.velocity.X / 10f;
            else projectile.rotation += rotateVal;
        }
    }
}