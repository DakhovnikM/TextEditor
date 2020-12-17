using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace TextEditor
{
    class MainWindowViewModel : BaseViewModel
    {

        private string filePath=null;
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                OnpropertyChanged(FilePath);
            }
        }

        private string stringFile;
        public string StringFile
        {
            get => stringFile;
            set
            {
                stringFile = value;
                OnpropertyChanged(StringFile);
            }
        }

        private int symbolStringFileCount;
        public int SymbolStringFileCount
        {
            get => symbolStringFileCount;
            set
            {
                symbolStringFileCount = value;
                OnpropertyChanged("SymbolStringFileCount");
            }
        }


        public ICommand OpenFileCommand { get; }
        private bool CanOpenFileCommandExecute(object p) => true;
        private void OnOpenFileCommandExecuted(object p)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы|*.txt";

            if (openFileDialog.ShowDialog() == true)
                FilePath = openFileDialog.FileName;

        }

        public ICommand SaveFileCommand;
        private bool CanSaveFileCommandExecute(object p) => true;
        private void OnSaveFileCommandExecuted(object p)
        {


        }

        public MainWindowViewModel()
        {
            OpenFileCommand = new RelayCommand(CanOpenFileCommandExecute, OnOpenFileCommandExecuted);
            SaveFileCommand = new RelayCommand(CanSaveFileCommandExecute, OnSaveFileCommandExecuted);
        }

        private void GetSymbolStringFileCount()
        {
            SymbolStringFileCount = stringFile.Length;
        }
    }
}
