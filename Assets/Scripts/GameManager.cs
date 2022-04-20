public static class GameManager
    {
        public static Configuration Config;
        private static MouseLook _cameraController;

        public static void Awake()
        {
            Config = new Configuration();
        }

        public static void SetCameraController(MouseLook m) => _cameraController ??= m;


        public static void ReloadConfig()
        {
            
        }
    }