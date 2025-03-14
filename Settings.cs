using BepInEx.Configuration;

namespace REPO_HD
{
	internal static class Settings
	{
		internal static ConfigEntry<bool> antialiasing;

		public static void InitConfig(ConfigFile config)
		{
			antialiasing = config.Bind("REPO_HD", "AntiAliasing", true, "Apply TAA+SMAA antialiasing to the game");
		}
	}
}
