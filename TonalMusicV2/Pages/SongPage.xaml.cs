using TonalMusicV2.PageModels;

namespace TonalMusicV2.Pages;

public partial class SongPage : ContentPage
{
	public SongPage(SongPageModel songPageModel)
	{
		InitializeComponent();
        BindingContext = songPageModel;
    }
}