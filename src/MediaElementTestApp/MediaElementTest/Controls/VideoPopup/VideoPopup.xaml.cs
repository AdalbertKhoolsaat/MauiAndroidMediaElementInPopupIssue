using CommunityToolkit.Maui.Views;

namespace MediaElementTest.Controls;

public partial class VideoPopup : Popup<string?>
{
	private readonly VideoPopupVM _vm;

	public VideoPopup(VideoPopupVM viewModel)
	{
		InitializeComponent();		
		BindingContext = _vm = viewModel;
	}

	//private void OnMediaEnded(object? sender, EventArgs e)
	//{
	//	// Minimal code-behind: just delegate to ViewModel command
	//	if (_vm.CloseCommand.CanExecute(null))
	//	{
	//		_vm.CloseCommand.Execute(null);
	//	}
	//}
}