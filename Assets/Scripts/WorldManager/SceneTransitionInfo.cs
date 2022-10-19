using UnityEngine;

[System.Serializable]
public struct SceneTransitionInfo
{
    /// <summary>
    /// Next scene's entry
    /// </summary>
    public int entryIndex;
    /// <summary>
    /// Character rotation on next scene
    /// </summary>
    public Vector3 rotation;
    /// <summary>
    /// Target Scene to Transition To
    /// </summary>
    public EnumGameScene targetScene;

}
