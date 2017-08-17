//Importações da classe
using MeuSegundoApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//Namespace da classe
namespace MeuSegundoApp.View
{
    //Anotação do Xamarin para compilar a classe usando o XAML para a parte visual (!!Nunca mexa nesta anotação!!)
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //Declaração da classe e fazendo ela herdar das propriedades da TabbedPage
    public partial class MenuPrincipal : TabbedPage
    {
        //Declarações
        ObservableCollection<Frase> frases;
        Frase objFrase;

        public MenuPrincipal()
        {
            //Método que inicializa os componentes visuais
            InitializeComponent();
            //Instancia a ObservableCollection
            frases = new ObservableCollection<Frase>();
            //Instancia o objeto da classe Frase
            objFrase = new Frase();

        }
        //Método de clique do botão Salvar
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MeuEntry.Text))
            {
                //Insere na propriedade da frase o valor digitado no campo
                objFrase.MinhaFrase = MeuEntry.Text;
                //Insere na ObservableCollection o objeto
                frases.Add(objFrase);
                //Manda a ListView carregar a lista novamente
                MinhaListView.ItemsSource = frases;
                //Mensagem de successo ao salvar
                DisplayAlert("Salvo com sucesso!", null, "Ok");
                //Esvaziar o campo do formulário
                MeuEntry.Text = "";
            }
            else
            {
                //Mensagem de erro ao salvar
                DisplayAlert("Preencha um valor no campo!", null, "Ok");
            }
        }
        /*Eventos de foco do formulário de inserção*/
        //Campo com foco
        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            //Mudança da cor do texto do label
            MeuLabel.TextColor = Color.CadetBlue;
            //Mudança na rotação do label (em graus)
            MeuLabel.RotationY = 22.5;
            //Mudança da cor do texto do entry
            MeuEntry.TextColor = Color.CadetBlue;
        }
        //Campo sem foco
        private void MeuEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(MeuEntry.Text))
            {
                //Mudança na rotação do label (em graus)
                MeuLabel.RotationY = -22.5;
                //Mudança da cor do texto do label
                MeuLabel.TextColor = Color.Red;
                //Mudança da cor do texto do entry
                MeuEntry.TextColor = Color.Red;
                //Mudança na rotação do entry (em graus)
                MeuEntry.RotationY = -22.5;
            }
            else
            {
                //Mudança na rotação do label (em graus)
                MeuLabel.RotationY = 0;
                //Mudança da cor do texto do label
                MeuLabel.TextColor = Color.CadetBlue;
                //Mudança da cor do texto do entry
                MeuEntry.TextColor = Color.CadetBlue;
                //Mudança na rotação do entry (em graus)
                MeuEntry.RotationY = 0;
            }
        }
    }
}