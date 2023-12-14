using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialCharacterController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private CharacterMapping _characterMapping;
    
    private string _id;
    private Character _character;

    public float FocusAngle { get; private set; }

    /// <summary>
    /// Initializes the character controller.
    /// Must be called before using the controller.
    /// </summary>
    /// <param name="id">Character ID</param>
    /// <param name="angle">Focus Angle for Camera</param>
    public void Initialize(string id, float angle)
    {
        FocusAngle = angle;
        
        _characterMapping ??= CharacterMapping.Instance;
        Debug.Log("Got character mapping");
        _id = id;
        _character = _characterMapping.GetCharacter(id);
        Debug.Log($"Initialized with Character: {_character.GetName()}");
        
        
        //TrySetExpression("idle");
    }
    
    public void TrySetExpression(string expression)
    {
        _spriteRenderer.sprite = _character.GetSprite(expression);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
