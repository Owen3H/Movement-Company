using GameNetcodeStuff;
using HarmonyLib;
using MovementCompanyEnhanced.Component;
using MovementCompanyEnhanced.Core;
using System.Collections;
using UnityEngine;

namespace MovementCompanyEnhanced.Patches {
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerPatch {
        [HarmonyPostfix]
        [HarmonyPatch("PlayerJump")]
        public static IEnumerator PlayerJumpPatch(IEnumerator __result) {
            while (__result.MoveNext()) {
                var cur = __result.Current;
                if (cur is not WaitForSeconds) {
                    yield return cur;
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("SpawnPlayerAnimation")]
        public static void SpawnPlayerPatch(PlayerControllerB __instance) {
            // Shouldn't ever happen here but just in-case.
            if (__instance == null)
                return;

            if (__instance.GetComponentInChildren<CustomMovement>() != null) 
                return;

            PlayerControllerB player = __instance;
            if (player.IsOwner && __instance.isPlayerControlled) {
                player.gameObject.AddComponent<CustomMovement>().player = __instance;
                Plugin.Logger.LogInfo("Client player was given the movement script.");
            }
        }
    }
}