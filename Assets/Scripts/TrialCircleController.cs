using System;
using System.Collections.Generic;
using UnityEngine;

public class TrialCircleController : MonoBehaviour
{
    // Constants
    private const float zero = 0.000f;
    private const float four = 4.000f;
    private const float lPos = 3.736f;
    private const float sPos = 1.430f;
    private const float cPos = 2.828f;
    private const float yPos = 1.969f;
    
    private Vector3[] _positions;
    private Quaternion[] _rotations;

    private string[] _ids;
    
    private readonly Vector3 _positionMonokuma = new Vector3(0, 0, 0);
    private readonly Vector3 _positionMonomi   = new Vector3(0, 0, 0);

    
    // Public Fields
    
    // Serialized Fields
    [SerializeField] private TrialCameraController _cameraController;
    [SerializeField] private GameObject trialCircleObject;
    [SerializeField] private GameObject _characterPrefab;
    
    // Private Field
    private Dictionary<string, TrialCharacterController> _characters;



    // Start is called before the first frame update
    private void Awake()
    {
        _positions = new Vector3[]
        {
            new Vector3(zero, yPos, -four),
            new Vector3(sPos, yPos, -lPos),
            new Vector3(cPos, yPos, -cPos),
            new Vector3(lPos, yPos, -sPos),
            
            new Vector3(four, yPos, zero),
            new Vector3(lPos, yPos, sPos),
            new Vector3(cPos, yPos, cPos),
            new Vector3(sPos, yPos, lPos),
            
            new Vector3(zero, yPos, four),
            new Vector3(-sPos, yPos, lPos),
            new Vector3(-cPos, yPos, cPos),
            new Vector3(-lPos, yPos, sPos),
            
            new Vector3(-four, yPos, zero),
            new Vector3(-lPos, yPos, -sPos),
            new Vector3(-cPos, yPos, -cPos),
            new Vector3(-sPos, yPos, -lPos)
        };


        _rotations = new Quaternion[]
        {
            Quaternion.Euler(0f, 180.0f, 0f),
            Quaternion.Euler(0f, 157.5f, 0f),
            Quaternion.Euler(0f, 135.0f, 0f),
            Quaternion.Euler(0f, 112.5f, 0f),

            Quaternion.Euler(0f, 90.0f, 0f),
            Quaternion.Euler(0f, 67.5f, 0f),
            Quaternion.Euler(0f, 45.0f, 0f),
            Quaternion.Euler(0f, 22.5f, 0f),

            Quaternion.Euler(0f, 0.0f, 0f),
            Quaternion.Euler(0f, 337.5f, 0f),
            Quaternion.Euler(0f, 315.0f, 0f),
            Quaternion.Euler(0f, 292.5f, 0f),

            Quaternion.Euler(0f, 270.0f, 0f),
            Quaternion.Euler(0f, 247.5f, 0f),
            Quaternion.Euler(0f, 225.0f, 0f),
            Quaternion.Euler(0f, 202.5f, 0f)
        };

        _ids = new string[]
        {
            "CH-01",
            "CH-02",
            "CH-03",
            "CH-04",
            "CH-05",
            "CH-06",
            "CH-07",
            "CH-08",
            "CH-09",
            "CH-10",
            "CH-11",
            "CH-12",
            "CH-13",
            "CH-14",
            "CH-15",
            "CH-16"
        };
        
        _characters = new Dictionary<string, TrialCharacterController>();
        
    }

    private void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject instance = Instantiate(_characterPrefab, _positions[i], _rotations[i]);
            instance.transform.parent = trialCircleObject.transform;
            TrialCharacterController character = instance.GetComponent<TrialCharacterController>();
            
            Debug.Log($"Initializing character {_ids[i]} with angle {_rotations[i].eulerAngles.y}");
            character.Initialize(_ids[i], _rotations[i].eulerAngles.y);
            _characters.Add(_ids[i], character);
            
        }
        
        
    }
    
    // TODO - Review Usage
    public void AssignPosition(int index, Character ch)
    {
        throw new NotImplementedException();
    }
    
    public void SetExpression(string id, string expression)
    {
        if (_characters[id] is null) Debug.Log($"Char {{{id}}} is null");
        if (expression is null) Debug.Log($"Expression is null");
        
        _characters[id].TrySetExpression(expression);
    }

    public void SetFocusTarget(string id)
    {
        if (_characters[id] is null) Debug.Log($"Char {{{id}}} is null");
        
        
        _cameraController.SetFocusAngle(_characters[id].FocusAngle);
        


    }
}
