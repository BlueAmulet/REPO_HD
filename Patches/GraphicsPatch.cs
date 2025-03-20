using HarmonyLib;
using UnityEngine;

namespace REPO_HD.Patches
{
	[HarmonyPatch(typeof(GraphicsManager))]
	internal static class GraphicsPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch(nameof(GraphicsManager.UpdateRenderSize))]
		public static bool PrefixUpdateRenderSize()
		{
			// Don't do anything here
			return false;
		}
	}
}
