using TonalMusicV2.PageModels;

namespace TonalMusicV2
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
