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
            Projectile.width = width;
            Projectile.height = height;
            //generic
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.light = 1.5f;
            Projectile.tileCollide = false;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            Main.projFrames[Projectile.type] = 1;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
        }

        public override void AI()
        {
            //maintain
            Player player = Main.player[Projectile.owner];
            MyPlayer myPlayer = player.GetModPlayer<MyPlayer>();
            if (!player.active)
            {
                Projectile.active = false;
                return;
            }
            if (player.dead)
            {
                myPlayer.currentLightPet = "";
            }
            if (myPlayer.currentLightPet == this.GetType().Name)
            {
                Projectile.timeLeft = 2;
            }

            //move
            Projectile.direction = player.direction;

            float target_x;
            if (player.direction == -1) target_x = player.Center.X - (Projectile.width * 2);
            else target_x = player.Center.X + Projectile.width;
            float target_y = player.position.Y - Projectile.height;

            float dist_x = target_x - Projectile.position.X;
            float dist_y = target_y - Projectile.position.Y;

            if (Math.Abs(dist_x) > 1) Projectile.velocity.X = dist_x / 20f;
            else Projectile.velocity.X = 0;
            if (Math.Abs(dist_y) > 1) Projectile.velocity.Y = dist_y / 20f;
            else Projectile.velocity.Y = 0;

            //tilt or rotate (rotate=true && projectile.rotation=0 prevents this)
            if (!rotate) Projectile.rotation = Projectile.velocity.X / 10f;
            else Projectile.rotation += rotateVal;
        }
    }
}