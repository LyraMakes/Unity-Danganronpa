using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character
{
    private readonly string _characterId;
    private readonly string _characterName;
    private readonly Dictionary<string, Sprite> _spriteDictionary;

    public Character(string id, string name)
    {
        _characterId = id;
        _characterName = name;
        _spriteDictionary = new Dictionary<string, Sprite>();

        foreach (Sprite sprite in GetSpriteNames(_characterId))
        {
            _spriteDictionary.Add(TrimName(sprite.name), sprite);
        }
        
    }

    public string GetId() => _characterId;
    public string GetName() => _characterName;
    public Sprite GetSprite(string sprite_name) => _spriteDictionary[sprite_name];

    

    private static string TrimName(string name_string) => name_string[5..];
    private static IEnumerable<Sprite> GetSpriteNames(string prefix) =>
        Resources.LoadAll<Sprite>($"Sprites/Characters/FullBody/{prefix}-");
}
