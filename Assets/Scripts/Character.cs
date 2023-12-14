using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character
{
    private readonly string _characterId;
    private readonly string _characterName;
    
    private readonly Dictionary<string, Sprite> _spriteDictionary;

    private readonly SpriteManager _spriteManager;
    
    public Character(string id, string name, SpriteManager spriteManager)
    {
        _characterId = id;
        _characterName = name;
        _spriteDictionary = new Dictionary<string, Sprite>();

        _spriteManager = spriteManager;
        
        foreach (Sprite sprite in GetSpriteNames(_characterId))
        {
            _spriteDictionary.Add(TrimName(sprite.name), sprite);
        }
        
    }

    public string GetId() => _characterId;
    public string GetName() => _characterName;
    public Sprite GetSprite(string spriteName) => _spriteDictionary[spriteName];
    private IEnumerable<Sprite> GetSpriteNames(string prefix) => _spriteManager.GetAll(prefix);

    

    private static string TrimName(string nameString) => nameString[6..];
}
