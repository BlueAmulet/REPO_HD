using BepInEx.Configuration;

namespace REPO_HD
{
	internal static class Settings
	{
		internal static ConfigEntry<bool> AntiAliasing;

		public static void InitConfig(ConfigFile config)
		{
			AntiAliasing = config.Bind("REPO_HD", "AntiAliasing", true, "Apply TAA+SMAA antialiasing to the game");
		}
	}
}
