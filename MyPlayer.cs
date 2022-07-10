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

        public override void SaveData(TagCompound tag)
        {
            tag.Add("reveal", reveal);
        }

        public override void LoadData(TagCompound tag)
        {
            reveal = Commons.TryGet<bool>(tag, "reveal", false);
        }
    }
}
