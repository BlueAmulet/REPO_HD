using HarmonyLib;
using UnityEngine;

namespace REPO_HD.Patches
{
	[HarmonyPatch(typeof(ExtractionPoint))]
	internal static class ExtractionPointPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch(nameof(ExtractionPoint.Start))]
		public static void PrefixStart(ref ExtractionPoint __instance)
		{
			if (Settings.FlickerFix.Value)
			{
				REPO_HD.Log.LogInfo("Fixing extraction point text flicker");
				__instance.haulGoalScreen.transform.localPosition += new Vector3(0f, 0f, -0.001f);
			}
		}
	}
}
