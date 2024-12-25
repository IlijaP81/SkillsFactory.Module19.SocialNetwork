Проект «Социальная сеть» предоставляет следующие возможности:
  Просмотр информации о всех пользователях социальной сети
  Просмотр информации о своём профиле
  Редактирование своего профиля
  Просмотр списка друзей 
  Добавление в друзья
  Исключение из друзей 
  Написать сообщение
  Просмотр входящих сообщений
  Просмотр исходящих сообщений
  Удаление сообщений
  Удаление своего профиля и всех относящиеся к нему сведений

ПЕРЕЧЕНЬ ДОРАБОТОК.
РАЗДЕЛ Business Logic Layer:

в папку Exceptions добавлены дополнительные «узкие» исключения: EmailAllreadyExistException, WrongPasswordException.

в папку Models добавлены:
  класс UserRegistrationData, поля которого определяют данные, необходимые для регистрации пользователя.
  класс Message, конструктор которого инициализирует поля класса, определяющие структуру сообщения. Соответствует структуре     
  таблицы БД messages.   
  класс MessageSendingData, поля которого определяют данные, необходимые для отправки сообщения.

в папку Services добавлены: 
  в класс FriendService добавлен метод FindSingleFriend. Вызывает метод FindSingleByUserIdAndFriendId класса FriendRepository 
  (см.ниже).
  в класс UserService добавлен метод ShowAllUsers, реализующий вывод на консоль всех зарегистрированных пользователей.

РАЗДЕЛ Data Access Layer:

в папку Entities добавлен FriendEntity, поля которого определяют данные, необходимые для связи пользователей отношением «друзья». Соответствует структуре таблицы БД friends.  

в папку Repositories добавлены:

  в класс FriendRepository добавлен метод FindSingleByUserIdAndFriendId, возвращающий запись таблицы friends, соответствующей   
  id пользователя и пользователя-друга. Используется для проверки наличия пользователя среди друзей при добавлении друзей и при   удалении пользователя из списка друзей. Вызов из метода FindSingleFriend, добавленного в класс FriendService раздела Business   Logic Layer – Services.
  
  в класс UserRepository добавлен метод DeleteById, удаляющий пользователя и относящиеся к нему сведения из таблиц БД users,   
  friends, messages.

РАЗДЕЛ Presentation Logic Layer:

в папку Views добавлены: 

  класс RegistrationView, обеспечивающий диалог с пользователем и вызов метода регистрации пользователя.
  
  класс UserIncomingMessageView, реализующий подсчет количества входящих сообщений и их вывод на консоль (опционально).
  
  класс UserOutcomingMessageView, реализующий подсчет количества исходящих сообщений и их вывод на консоль (опционально).
  
  класс MessageDeletingView, обеспечивающий вывод входящих/исходящих сообщений на консоль, диалог с пользователем и вызов 
  метода удаления сообщений Delete класса MessageService раздела Business Logic Layer - Services.
  
  класс UserDeletingView, обеспечивающий вызов метода удаления пользователя Delete класса UserService раздела Business Logic 
  Layer - Services. В свою очередь, метод Delete вызывает метод DeleteById класса UserRepository раздела Data Access Layer – 
  Repositories.

в папку Helpers добавлен класс InfoMessage, реализующий информационные сообщения.

Изменения в классе Program.cs связаны с добавлением классов RegistrationView, UserIncomingMessageView, UserOutcomingMessageView, MessageDeletingView, UserDeletingView.

БД social_network_bd расположена в каталоге ...SocialNetwork\SocialNetwork\bin\Debug\net8.0\DAL\DB
В качестве примера подготовлен пользователь a@bk.ru, пароль 1234567375663, id = 3, имеющий сообщения и друзей.
