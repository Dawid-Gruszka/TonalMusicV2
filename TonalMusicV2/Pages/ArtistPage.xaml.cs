
using TonalMusicV2.PageModels;

namespace TonalMusicV2.Pages;

public partial class ArtistPage : ContentPage
{
	public ArtistPage(ArtistPageModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}