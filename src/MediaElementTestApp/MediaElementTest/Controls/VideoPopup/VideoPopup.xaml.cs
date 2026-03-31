using CommunityToolkit.Maui.Views;

namespace MediaElementTest.Controls;

public partial class VideoPopup : Popup
{
	public VideoPopup(VideoPopupVM viewModel)
	{
		InitializeComponent();		
		BindingContext = viewModel;
	}
}