
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace ChatBot
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Chat> listaMensajes;

        public MainWindow()
        {
            InitializeComponent();

            listaMensajes = new ObservableCollection<Chat>();
            conversacionItemsControl.DataContext = listaMensajes;
        }

        private void CommandBinding_ComprobarConexionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Conexión correcta con el servidor del Bot", "Comprobar conexión", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CommandBinding_SalirExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void CommandBinding_NuevaConversacionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            listaMensajes.Clear();
        }

        private void CommandBinding_NuevaGuardarConversacionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
           if (listaMensajes != null && listaMensajes.Count > 0 )
           {
                e.CanExecute = true;
           }
            else e.CanExecute = false;
        }

        private void CommandBinding_GuardarConversacionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, conversacionItemsControl.ItemsSource.ToString());
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar el archivo", "Pelicula", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CommandBinding_EnviarCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textoAEscribirTextBox.Text != "" && textoAEscribirTextBox != null)
            {
                e.CanExecute = true;
            }
            else e.CanExecute = false;
        }

        private void CommandBinding_EnviarExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            listaMensajes.Add(new Chat(textoAEscribirTextBox.Text.ToString(), "Usuario"));
            listaMensajes.Add(new Chat("Lo siento, estoy un poco cansado para hablar.", "Robot"));
            textoAEscribirTextBox.Text = "";
        }
    }
}
