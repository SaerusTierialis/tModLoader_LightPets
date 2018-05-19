using Terraria.ModLoader;
using Terraria;

namespace LightPets
{
	class LightPets : Mod
	{
		public LightPets()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
    }
}
