using PracticoAppMobil.Modelo;
using PracticoAppMobil.Servicios;


namespace PracticoAppMobil
{
    public partial class MainPage : ContentPage
    {
        private readonly IUsuarioService _usuarioService;

        public MainPage(IUsuarioService service)
        {
            InitializeComponent();
            _usuarioService = service;

           
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            var data = await _usuarioService.Obtener();
            collectionViewPersonajes.ItemsSource = data;
            loading.IsVisible = false;
        }

        private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = e.NewTextValue;
            var filteredData = await _usuarioService.Filtrar(searchTerm);
            collectionViewPersonajes.ItemsSource = filteredData;
        }
    }
}