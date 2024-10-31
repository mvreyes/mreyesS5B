using mreyesS5B.Utils;

namespace mreyesS5B
{
    public partial class App : Application
    {
        public static PersonRepository personRepo { get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new Views.Principal();
            personRepo = personRepository;

        }
    }
}
