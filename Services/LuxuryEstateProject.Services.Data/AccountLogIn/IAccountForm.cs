namespace LuxuryEstateProject.Services.Data.AccountLogIn
{
    using LuxuryEstate.Web.ViewModels;

    public interface IAccountForm
    {
        void RegisterAccount(SignUpInputModel input);
    }
}
