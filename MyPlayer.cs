using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace LightPets
{
    class MyPlayer : ModPlayer
    {
        public bool reveal = true;
        public string currentLightPet = "";

        public override void ResetEffects()
        {
            currentLightPet = "";
        }

        public override TagCompound Save()
        {
            return new TagCompound {
                { "reveal", reveal},
            };
        }

        public override void Load(TagCompound tag)
        {
            reveal = Commons.TryGet<bool>(tag, "reveal", false);
        }
    }
}
