using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

using TextEditor.BL;

namespace TextEditor
{
    class MainWindowViewModel : BaseViewModel
    {
        FileManager fileManager;


        private string filePath;
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                OnpropertyChanged();
            }
        }

        private string stringFile;
        public string StringFile
        {
            get => stringFile;
            set
            {
                stringFile = value;
                OnpropertyChanged();
            }
        }

        private int symbolStringFileCount;
        public int SymbolStringFileCount
        {
            get => symbolStringFileCount;
            set
            {
                symbolStringFileCount = value;
                OnpropertyChanged();
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

        public ICommand SaveFileCommand;
        private bool CanSaveFileCommandExecute(object p) => true;
        private void OnSaveFileCommandExecuted(object p)
        {


        }
        #endregion
        public MainWindowViewModel()
        {
            fileManager = new FileManager();

            GetFilePathCommand = new RelayCommand(CanGetFilePathCommandExecute, OnGetFilePathCommandExecuted);
            OpenFileCommand = new RelayCommand(CanOpenFileCommandExecute, OnOpenFileCommandExecuted);
            SaveFileCommand = new RelayCommand(CanSaveFileCommandExecute, OnSaveFileCommandExecuted);
        }

        private void GetSymbolStringFileCount()
        {
            SymbolStringFileCount = stringFile.Length;
        }
    }
}
