public static class Fields
{
     public static class Tags
     {
          public const string PlayerTag = "Player";
          public const string Canvas = "Canvas";
          public const string ChestKey = "ChestKey";
          public const string Chest = "Chest";
          public const string DoorKey = "DoorKey";
     }

     public static class AnimationState
     {
          public const string Door = "Door";
          public const string Chest = "Chest";
          public const string FadeAnimation = "FadeAnimation";
          public const string PlayerMove = "HorizontalMove";
     }

     public static class Paths
     {
          public const string Blocks = "Blocks";
          public const string StartBlocks = "StartBlocks";
     }

     public static class Generation
     {
          public const float BlockSize = 20;
          public const float BlockBaseSpeed = 0.02f;
          public const float BlockSpeedIncrease = 0.01f;
          public const float LavaPosition = -20;
          public const float LavaOffset = 9;
          public const int BlocksNumberOffset = 2;
          public const int TransformPos = 1;
     }

     public static class Buffs
     {
          public const float BootsAcceleration = 1.6f;
          public const float UsingTime = 10f; 
          public const float DirtSlowdown = 0.5f;
          public const int PanelIndex = 0;
          public const int BootsIconIndex = 0;
          public const int HelmetIconIndex = 1;
          public const int LavaRingIconIndex = 2;
          public const int ImmortalityIconIndex = 3;
     }

     public static class UIBehaviour
     {
          public const float MaxDelay = 10f;
          public const int Shift = 1;
          public const int Space = 150;
          public const int PointY = 50;
          public const float ResumeTimeScale = 1f;
          public const float PauseTimeScale = 0f;
     }

     public static class Coins
     {
          public const float DestroyTime = 1;
          public const int Min = 1;
          public const int Max = 5;
     }
     
     public static class Score
     {
          public const int CoinMultiplier = 2;
          public const int DiamondMultiplier = 40;
     }
     
     public static class Audio
     {
          public const string MasterVolumeName = "MasterVolume";
          public const float NormalVolume = -6f;
          public const float MinVolume = -80f;
     }

     public static class Key
     {
          public const double Epsilon = 1e-9;
          public const float Speed = 9;
     }

     public static class Player
     {
          public const float ClimbSpeed = 10;
          public const float GroundCheckRadius = 0.4f;
          public const float LadderCheckRadius = 0.3f;
          public const float SlopeCheckRadius = 0.4f;
          public const int SlopeJumpIncrease = 2;
          public const string HorizontalAxisName = "Horizontal";
     }
     
     public static class CameraMovement
     {
          public const float SmoothTime = 0.25f;
          public const float ZOffset = -10f;
          public const float YOffset = 3f;
     }
    
     public static class Scoreboard
     {
          public const string EmptyScore = "-";
          public const string EmptyName = "-";
          public const string PrivateCode = "BYQx1VscdE2NTwBAkz66NgqHwFtwSJ2kOAzq4MNVnwLw";
          public const string PublicCode = "665d86768f40bb12c863015d";
          public const string WebURL = "http://dreamlo.com/lb/";
          public const string RankSeparator = ".";
          public const string LoadingName = "Fetching...";
          public const int IndexationToNumConverter = 1;
     }

     public static class Requests
     {
          public const string QuerySeparator = "/";
          public const string EntrySeparator = "|";
          public const string LineSeparator = "\n";
          public const string AddRequest = "/add/";
          public const string GetFromStartRequest = "/pipe/0/";
          public const string SuccessMessage = ":Recived: ";
          public const string ProtocolErrorMessage = ":HTTP Error: ";
          public const string DefaultErrorMessage = ":Error: ";
          public const int UserNameIndex = 0;
          public const int ScoreIndex = 1;
     }

     public static class SaveSystem
     {
          public const string PlayerCoins = "Coins";
          public const string PlayerDiamonds = "Diamonds";
          public const string Distance = "Distance";
          public const string MaxDistance = "MaxDistance";
     }

     public static class Fade
     {
          public const string FadeMaterial = "_StencilComp";
          public const int FadeAnimationTime = 1; 
     }

     public static class AudioFade
     {
          public const float FadeInLength = 2;
          public const float FadeInTargetVolume = 1;
          public const float FadeOutLength = 2;
          public const float FadeOutTargetVolume = 0;
     }

     public static class Diamonds
     {
          public const int DiamondsAmount = 1;
          public const float DestroyTime = 1;
     }
     
     public const float DoorOpenTime = 0.8f;
     public const string DeathSceneName = "DeathScene";
     public const float CountAnimationDuration = 1;
     public const float StalactiteShakeTime = 0.25f;
}
