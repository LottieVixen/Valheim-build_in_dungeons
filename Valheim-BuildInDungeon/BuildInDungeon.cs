using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Valheim_BuildInDungeon
{
	[BepInPlugin(GUID, Name, Version)]
	[BepInProcess("valheim.exe")]
	[HarmonyPatch]
	public class ChangePlacePiece : BaseUnityPlugin
	{
		private const string GUID = "valheim.lottievixen.build_in_dungeons";
		private const string Name = "Build In Dungeons";
        private const string Version = "1.0.0.0";

        void Awake()
        {
            var harmony = new Harmony("valheim.lottievixen.build_in_dungeons");
            harmony.PatchAll();
        }

		[HarmonyPostfix]
		[HarmonyPatch(typeof(Piece), "Awake")]
		static void Placement_Patch(Piece __instance)
		{
			__instance.m_allowedInDungeons = true;
		}
		/* removed as it is unnessecary
		[HarmonyPostfix]
		[HarmonyPatch(typeof(Character), "InInterior")]
		static void Placement_char(ref bool __result) {
			__result = false;
		}
		*/
	}
}
