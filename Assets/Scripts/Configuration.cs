public class Configuration
{
    public float mouseXSensitivity { get; private set; }
    public float mouseYSensitivity { get; private set; }
    
    public float volumeBGM { get; private set; }
    public float volumeSFX { get; private set; }
    public float volumeVO { get; private set; }
    
    public float reticleSpeed { get; private set; }
    
    public bool movementBobbing { get; private set; }
    
    
    
    public void Reset()
    {
        mouseXSensitivity = 1.0f;
        mouseYSensitivity = 1.0f;
        
        volumeBGM = 1.0f;
        volumeSFX = 1.0f;
        volumeVO = 1.0f;
        
        reticleSpeed = 1.0f;
        
        movementBobbing = true;
    }
    
    public void SetSensitivity(float x, float y)
    {
        mouseXSensitivity = x;
        mouseYSensitivity = y;
        
    }
}