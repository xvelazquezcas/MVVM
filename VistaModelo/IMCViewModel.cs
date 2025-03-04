using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CalcularIMC_MAUI
{
    public class IMCViewModel : INotifyPropertyChanged  
    {
        private string _peso;
        private string _altura;
        private string _imc;
        private string _resultado;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Peso
        {
            get => _peso;
            set
            {
                _peso = value;
                OnPropertyChanged();
            }
        }

        public string Altura
        {
            get => _altura;
            set
            {
                _altura = value;
                OnPropertyChanged();
            }
        }

        public string IMC
        {
            get => _imc;
            set
            {
                _imc = value;
                OnPropertyChanged();
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcularIMCCommand { get; }

        public IMCViewModel()
        {
            CalcularIMCCommand = new Command(CalcularIMC);
        }

        private void CalcularIMC()
        {
            if (double.TryParse(Peso, out double peso) && double.TryParse(Altura, out double altura) && altura > 0)
            {
                double imc = peso / (altura * altura);
                IMC = $"IMC: {imc:F2}";  // Formatear el IMC a dos decimales.

                if (imc < 18.5)
                    Resultado = "Te hace falta comer";
                else if (imc <= 24.9)
                    Resultado = "Tu peso es normal";
                else if (imc <= 29.9)
                    Resultado = "Estás pasadito";
                else
                    Resultado = "Tienes obesidad, cuídate";
            }
            else
            {
                Resultado = "Datos inválidos, ingresa valores numéricos";
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

