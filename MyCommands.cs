using Terraria;
using Terraria.ModLoader;

namespace LightPets
{
    class Command_reveal : CommandTemplate
    {
        public Command_reveal()
        {
            name = "reveal";
            argstr = "";
            desc = "toggle light pet treasure reveal";
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            MyPlayer localMyPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>();
            localMyPlayer.reveal = !localMyPlayer.reveal;
            if (localMyPlayer.reveal) Main.NewText("Light pets now reveal treasure.");
            else Main.NewText("Light pets no longer reveal treasure.");
        }
    }

    public abstract class CommandTemplate : ModCommand
    {
        public string name, argstr, desc;

        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return name; }
        }

        public override string Usage
        {
            get { return "/" + name + " " + argstr; }
        }

        public override string Description
        {
            get { return "LightPets: " + desc; }
        }
    }
}
