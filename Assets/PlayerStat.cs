using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum StateType
{
    health,speed,mp
}
[CreateAssetMenu]
public class PlayerStat : ScriptableObject
{
    public List<playerState> player = new List<playerState>();

    public playerState GetState(StateType type)
    {
        return player.FirstOrDefault(i => i.type == type);
    }
}
[System.Serializable]
public class playerState
{
    public StateType type;
    public float Stat;
}