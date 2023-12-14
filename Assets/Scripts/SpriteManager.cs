using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpriteManager
{
    private Sprite[] _spriteRegistry;

    public SpriteManager()
    {
        _spriteRegistry = Resources.LoadAll<Sprite>(@"Sprites/Characters/FullBody/");
    }

    public IEnumerable<Sprite> GetAll(string prefix) => 
        _spriteRegistry.Where(x => x.name.StartsWith(prefix));
    
    
}