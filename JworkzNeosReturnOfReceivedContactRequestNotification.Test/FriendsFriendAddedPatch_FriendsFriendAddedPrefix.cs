using JworkzNeosMod.Patches;
using FrooxEngine;
using CloudX.Shared;

namespace JworkzNeosReturnOfReceivedContactRequestNotification.Test;

public class FriendsFriendAddedPatch_FriendsFriendAddedPrefix
{
    [Fact]
    public void FriendsFriendAddedPrefix_RequestedStatus_SetsIsAcceptedToFalse()
    {
        var friend = new Friend
        {
            FriendStatus = FriendStatus.Requested,
            IsAccepted = true
        };

        FriendsFriendAddedPatch.FriendsFriendAddedPrefix(ref friend);

        Assert.False(friend.IsAccepted);
    }

    [Theory]
    [InlineData(FriendStatus.Blocked, true)]
    [InlineData(FriendStatus.Blocked, false)]
    [InlineData(FriendStatus.Accepted, true)]
    [InlineData(FriendStatus.Accepted, false)]
    [InlineData(FriendStatus.SearchResult, true)]
    [InlineData(FriendStatus.SearchResult, false)]
    [InlineData(FriendStatus.None, false)]
    [InlineData(FriendStatus.None, true)]
    [InlineData(FriendStatus.Ignored, false)]
    [InlineData(FriendStatus.Ignored, true)]
    public void FriendsFriendAddedPrefix_OtherStatuses_KeepsIsAcceptedSameValue(FriendStatus status, bool isAccpetedExpected)
    {
        var friend = new Friend
        {
            FriendStatus = status,
            IsAccepted = isAccpetedExpected
        };

        FriendsFriendAddedPatch.FriendsFriendAddedPrefix(ref friend);

        Assert.Equal(friend.IsAccepted, isAccpetedExpected);
    }
}