using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class HomeViewModel : ViewModelBase, IQueryAttributable
{
    public HomeViewModel(IMessageService messageService) : base(messageService)
    {
    }

    public UserSignInEntity? _userSignInEntity;

    public string NickName { get; private set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.Count <= 0) return;

        this._userSignInEntity = (UserSignInEntity)query[nameof(UserSignInEntity)];
        this.NickName = this._userSignInEntity.NickName;
    }
}