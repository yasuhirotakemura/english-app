﻿using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class UserProfileSetupView : BaseContentPage
{
	public UserProfileSetupView(UserProfileSetupViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;

        this.HideBackButton();
    }
}