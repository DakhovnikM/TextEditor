using Microsoft.Win32;
using System;
using System.Windows.Input;
using TextEditor.BL;
using TextEditor.Commands;
using TextEditor.ViewModel;

namespace TextEditor
{
    class MainWindowViewModel : BaseViewModel
    {
        readonly FileManager fileManager;

        private string filePath;
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                OnPropertyChanged();
            }
        }

        private string stringFile;
        public string StringFile
        {
            get => stringFile;
            set
            {
                stringFile = value;
                OnPropertyChanged();
            }
        }

        #region Команды

        public ICommand GetFilePathCommand { get; }
        private bool CanGetFilePathCommandExecute(object p) => true;
        private void OnGetFilePathCommandExecuted(object p)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
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
