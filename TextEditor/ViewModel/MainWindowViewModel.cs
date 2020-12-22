using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using TextEditor.BL;
using TextEditor.Commands;

namespace TextEditor.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        readonly FileManager fileManager;

        private string _filePath;
        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged();
            }
        }

        private string _stringFile;
        public string StringFile
        {
            get => _stringFile;
            set
            {
                _stringFile = value;
                OnPropertyChanged();
            }
        }

        #region Команды

        public ICommand GetFilePathCommand { get; }
        private bool CanGetFilePathCommandExecute(object p) => true;
        private void OnGetFilePathCommandExecuted(object p)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы|*.txt"
            };

            if (openFileDialog.ShowDialog() == true)
                FilePath = openFileDialog.FileName;
        }

        public ICommand OpenFileCommand { get; }
        private bool CanOpenFileCommandExecute(object p) => true;
        private void OnOpenFileCommandExecuted(object p)
        {
            if (_filePath == null) return;
            try
            {
                StringFile = fileManager.GetString(FilePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ICommand SaveFileCommand { get; }
        private bool CanSaveFileCommandExecute(object p) => true;
        private void OnSaveFileCommandExecuted(object p)
        {
            fileManager.SaveString(FilePath, StringFile);
            MessageBox.Show("Файл успешно сохранен.");
        }
        #endregion

        public MainWindowViewModel()
        {
            fileManager = new FileManager();

            GetFilePathCommand = new RelayCommand(CanGetFilePathCommandExecute, OnGetFilePathCommandExecuted);
            OpenFileCommand = new RelayCommand(CanOpenFileCommandExecute, OnOpenFileCommandExecuted);
            SaveFileCommand = new RelayCommand(CanSaveFileCommandExecute, OnSaveFileCommandExecuted);
        }
    }
}
