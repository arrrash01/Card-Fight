using UnityEngine;

[CreateAssetMenu(fileName = "LevelUpProgression", menuName = "Game/Level Up Progression")]
public class LevelUpProgression : ScriptableObject
{
    [System.Serializable]
    public class CharacterLevelData
    {
        public string characterName;
        public int[] hpIncreases;
        public int[] damageIncreases;
    }

    public CharacterLevelData[] characterLevelData;

    public int GetHPIncrease(string characterName, int level)
    {
        CharacterLevelData data = FindCharacterLevelData(characterName);
        if (data != null && level >= 0 && level < data.hpIncreases.Length)
        {
            return data.hpIncreases[level];
        }
        return 0;
    }

    public int GetDamageIncrease(string characterName, int level)
    {
        CharacterLevelData data = FindCharacterLevelData(characterName);
        if (data != null && level >= 0 && level < data.damageIncreases.Length)
        {
            return data.damageIncreases[level];
        }
        return 0;
    }

    private CharacterLevelData FindCharacterLevelData(string characterName)
    {
        foreach (CharacterLevelData data in characterLevelData)
        {
            if (data.characterName == characterName)
            {
                return data;
            }
        }
        return null;
    }
}