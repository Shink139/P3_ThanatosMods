using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using xTile;

namespace P3_ThanatosMods  
{
public class AnimationController
{
    private NPC npc;
    private AnimationState? currentState;

    public AnimationController(NPC npc)
    {
        this.npc = npc;
       Play("idle");
    }

    public void Play(string animationId)
    {
      AnimationData data =AnimationDatabase.Get(animationId);

        currentState = new AnimationState(data);

        SetFrame();
    }

     public void Update()
    {
        if (currentState == null)
            return;

        currentState.Timer++;

        // 没到切帧时间
        if (currentState.Timer < currentState.Data.FrameDuration)
            return;

        currentState.Timer = 0;

        currentState.FrameIndex++;

        // 动画结束
        if (currentState.FrameIndex >= currentState.Data.Frames.Length)
{
    if (currentState.Data.Loop)
    {
        currentState.FrameIndex = 0;
    }
    else
    {
        string next = currentState.Data.NextAnimation;

        if (!string.IsNullOrEmpty(next))
            Play(next);
        else
            currentState.Finished = true;

        return;
    }
}
        SetFrame();
    }

    private void SetFrame()
    {
        if (currentState == null)
            return;

        npc.Sprite.CurrentFrame = currentState.Data.Frames[currentState.FrameIndex];
    }
}}