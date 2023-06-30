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
        static void FriendsFriendAddedPrefix(ref Friend friend)
        {
            friend.IsAccepted = friend.FriendStatus != FriendStatus.Requested;
        }
    }
}
