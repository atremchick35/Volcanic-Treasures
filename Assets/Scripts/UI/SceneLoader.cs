using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Animator fadeAnimation;
        
        public void LoadSceneByName(string sceneName)
        {
            Time.timeScale = Fields.UIBehaviour.ResumeTimeScale;
            fadeAnimation.Play(Fields.AnimationState.FadeAnimation);
            StartCoroutine(Delay(Fields.Fade.FadeAnimationTime, sceneName));
        }

        public void Exit() => Application.Quit();

        private static IEnumerator Delay(int seconds, string sceneName)
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene(sceneName);
        }
    }
}