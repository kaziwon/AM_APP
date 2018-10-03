using App2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : MasterDetailPage
    {
        public Principal()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Jogadores>(this, "JogadoresAbrir", (sender) =>
            {
                Detail = new NavigationPage(new Jogadores());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<CadastrarJogador>(this, "CadastrarJogadorAbrir", (sender) =>
            {
                Detail = new NavigationPage(new CadastrarJogador());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<CadastrarTime>(this, "CadastrarTimeAbrir", (sender) =>
            {
                Detail = new NavigationPage(new CadastrarTime());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<CadastrarPartida>(this, "CadastrarPartidaAbrir", (sender) =>
            {
                Detail = new NavigationPage(new CadastrarPartida());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<DateModel>(this, "JogadorDetalhesAbrir", (sender) =>
            {
                Global.Jogador = sender;
                Detail = new NavigationPage(new JogadorDetalhes());
                IsPresented = false;
            });

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Jogadores>(this, "JogadoresAbrir");
            MessagingCenter.Unsubscribe<CadastrarJogador>(this, "CadastrarJogadorAbrir");
            MessagingCenter.Unsubscribe<CadastrarTime>(this, "CadastrarTimeAbrir");
            MessagingCenter.Unsubscribe<JogadorDetalhes>(this, "JogadorDetalhesAbrir");
        }
    }
}