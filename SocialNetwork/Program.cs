using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

namespace SocialNetwork;

class Program
{
    public static MessageService messageService;
    public static UserService userService;
    public static FriendService friendService;
    public static MainView mainView;
    public static RegistrationView registrationView;
    public static AuthenticationView authenticationView;
    public static UserMenuView userMenuView;
    public static UserInfoView userInfoView;
    public static UserDataUpdateView userDataUpdateView;
    public static MessageSendingView messageSendingView;
    public static UserIncomingMessageView userIncomingMessageView;
    public static UserOutcomingMessageView userOutcomingMessageView;
    public static MessageDeletingView messageDeletingView;
    public static FriendDataUpdateView friendDataUpdateView;
    public static UserDeletingView userDeletingView;

    static void Main(string[] args)
    {
        userService = new UserService();
        messageService = new MessageService();
        friendService = new FriendService();
        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticationView(userService);
        userMenuView = new UserMenuView(userService);
        userInfoView = new UserInfoView();
        userDataUpdateView = new UserDataUpdateView();
        messageSendingView = new MessageSendingView(messageService);
        userIncomingMessageView = new UserIncomingMessageView();
        userOutcomingMessageView = new UserOutcomingMessageView();
        messageDeletingView = new MessageDeletingView();
        friendDataUpdateView = new FriendDataUpdateView();
        userDeletingView = new UserDeletingView();

        while (true)
        {
            mainView.Show();
        }
    }
}
