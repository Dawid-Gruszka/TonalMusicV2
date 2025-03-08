using TonalMusicV2.PageModels;

namespace TonalMusicV2.Pages;

public partial class AlbumPage : ContentPage
{
	public AlbumPage(AlbumPageModel albumPageModel)
	{
		InitializeComponent();
        BindingContext = albumPageModel;
    }
}