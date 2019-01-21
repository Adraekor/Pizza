using Prism;
using Prism.Ioc;
using Cours2.ViewModels;
using Cours2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cours2.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cours2
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/RestaurantMenu");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            containerRegistry.RegisterForNavigation<NewPizza, NewPizzaViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantMenu, RestaurantMenuViewModel>();
            containerRegistry.RegisterForNavigation<PizzaDetails, PizzaDetailsViewModel>();

            containerRegistry.RegisterSingleton<IPizzaService, PizzaService>();
            containerRegistry.RegisterSingleton<IIngredientService, IngredientService>();
        }
    }
}
