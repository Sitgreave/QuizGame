using Sirius.Game.Letter;
namespace Game.Letter
{
    public class HiddenLetterContainer: LetterContainer
    {
        private void Start()
        {
            Hide();
        }

        public void Hide()
        {
            _letterText.alpha = 0;
        }

        public void Show()
        {
            _letterText.alpha = 1;
        }
    }
}