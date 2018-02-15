using UnityEngine;
using UnityEngine.UI;

public class MusicControlUI : MonoBehaviour {

    [SerializeField]
    [Tooltip ("Image to display while the music playing.")]
    private Sprite unmutedImage = null;
    [SerializeField]
    [Tooltip ("Image to display while the music is muted.")]
    private Sprite mutedImage = null;

    private Image image = null;

    private bool muted = false;

	private void Start () {
        image = GetComponent<Image>();
	}

    public void ToggleMute()
    {
        muted = !muted;
        if (muted)
        {
            image.sprite = mutedImage;
        }
        else
        {
            image.sprite = unmutedImage;
        }
    }
}
