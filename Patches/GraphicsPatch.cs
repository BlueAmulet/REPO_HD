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
			// Force RenderTexture to be the same as the game's resolution
			RenderTextureMain.instance.textureWidthOriginal = Screen.width;
			RenderTextureMain.instance.textureHeightOriginal = Screen.height;
			RenderTextureMain.instance.ResetResolution();
			return false;
		}
	}
}
