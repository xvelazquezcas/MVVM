using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.VistaModelo
{
    public class IMCViewModel : INotifyPropertyChanged
    {
        private double peso;
        private double altura;
        private double imc;
        private string resultado;

        public double Peso
        {
            get => peso;
            set
            {
                peso = value;
                OnPropertyChanged(nameof(Peso));
            }
        }

        public double Altura
        {
            get => altura;
            set
            {
                altura = value;
                OnPropertyChanged(nameof(Altura));
            }
        }

        public double IMC
        {
            get => imc;
            set
            {
                imc = value;
                OnPropertyChanged(nameof(IMC));
            }
        }

        public string Resultado
        {
            get => resultado;
            set
            {
                resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }

        public ICommand CalcularCommand { get; }

        public IMCViewModel()
        {
            CalcularCommand = new Command(CalcularIMC);
        }

        private void CalcularIMC()
        {
            if (Altura > 0)
            {
                IMC = Peso / (Altura * Altura);
                Resultado = ObtenerClasificacion(IMC);
            }
            else
            {
                Resultado = "Ingrese valores válidos";
            }
        }

        private string ObtenerClasificacion(double imc)
        {
            if (imc < 18.5) return "Bajo peso";
            if (imc < 24.9) return "Peso normal";
            if (imc < 29.9) return "Sobrepeso";
            return "Obesidad";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}