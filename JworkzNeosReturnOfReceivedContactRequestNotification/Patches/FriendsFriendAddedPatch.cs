using System;
using System.Threading.Tasks;
using HarmonyLib;
using System.Threading;
using System.Reflection;
using System.Text.RegularExpressions;
using CloudX.Shared;
using MonoMod.Utils;
using NeosModLoader;
using FrooxEngine;

namespace JworkzNeosMod.Patches
{
    [HarmonyPatch(typeof(NotificationPanel))]
    internal static class FriendsFriendAddedPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Friends_FriendAdded")]
        internal static void FriendsFriendAddedPrefix(ref Friend friend)
        {
            if (friend.FriendStatus == FriendStatus.Requested)
            {
                friend.IsAccepted = false;
            }
        }
    }
}
