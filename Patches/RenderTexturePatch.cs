using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace REPO_HD.Patches
{
	[HarmonyPatch(typeof(RenderTextureMain))]
	internal static class RenderTexturePatch
	{
		[HarmonyPostfix]
		[HarmonyPatch(nameof(RenderTextureMain.Start))]
		public static void PostfixStart(ref RenderTextureMain __instance)
		{
			if (!Settings.AntiAliasing.Value)
			{
				return;
			}
			for (int i = 0; i < __instance.cameras.Count; i++)
			{
				Camera camera = __instance.cameras[i];
				PostProcessLayer layer = camera.GetComponent<PostProcessLayer>();
				if (layer != null)
				{
					if (i == 0)
					{
						// Main camera gets TAA
						layer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
						REPO_HD.Log.LogInfo($"Enabled TAA on {camera}");
					}
					else
					{
						// Overlay camera gets SMAA, otherwise too blurry and ghosting
						layer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
						REPO_HD.Log.LogInfo($"Enabled SMAA on {camera}");
					}
				}
			}
		}

		[HarmonyPrefix]
		[HarmonyPatch(nameof(RenderTextureMain.Update))]
		public static void PrefixUpdate(ref RenderTextureMain __instance)
		{
			// Force RenderTexture to be the same as the game's resolution
			__instance.textureWidthOriginal = Screen.width;
			__instance.textureHeightOriginal = Screen.height;
		}
	}
}
