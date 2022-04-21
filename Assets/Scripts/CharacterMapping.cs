using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class CharacterMapping
{
    private readonly Dictionary<string, Character> _dictionary;

    public CharacterMapping()
    {
        // Read the file and create the dictionary from xml
        _dictionary = new Dictionary<string, Character>();
        XmlDocument doc = new XmlDocument();
        doc.Load(@"Assets/Resources/Dialogue/Map_Character.xml");
        XmlNodeList nodes = doc.SelectNodes("/character-map/character");
        if (nodes == null) throw new InvalidXmlException("CharacterMapping.xml is not valid");
        
        foreach (XmlNode node in nodes)
        {
            if (node.Attributes == null) continue;
            
            string id = node.Attributes["id"].Value;
            string name = node.InnerText;
            _dictionary.Add(id, new Character(id, name));
        }
    }
    
    public Character GetCharacter(string id) => _dictionary.ContainsKey(id) ? _dictionary[id] : null;
    public string GetCharacterName(string id) => _dictionary.ContainsKey(id) ? _dictionary[id].GetName() : null;
}
