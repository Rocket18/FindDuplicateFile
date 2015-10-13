using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DuplicateFile.BL;
using System.Timers;
using System.IO;
using System.Threading;

namespace FileDuplicate
{
    public class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IMessageService _messageService;
        private readonly IFileManager _mannager;

        public MainPresenter(IMainForm view, IMessageService messageService, IFileManager mannager)
        {
            _view = view;
            _messageService = messageService;
            _mannager = mannager;
            _view.setAlgotithm(_mannager.Algorithm());
            _view.ScanClick += _view_ScanClick;
            _view.ClearResult += _view_ClearResult;
            _view.DeleteFile += _view_DeleteFile;
            _view.OpenProperties += _view_OpenProperties;
            _view.OpenFolder += _view_OpenFolder;
            _view.DeleteDublicateFile += _view_DeleteDublicateFile;

        }

        void _view_DeleteDublicateFile(object sender, EventArgs e)
        {
            if (_messageService.ShowConfirm("Видалити всі дублікати???", "Програма сама обирає, які файли з групи будуть очищенні\nБажаєте продовжити?"))
            {

                _mannager.DeleteDuplicateFile();
                _view.Result(null);
                _messageService.ShowMessage("Всі дублікати видалено");
            }
        }

        void _view_OpenFolder(object sender, EventArgs e)
        {
            string fullName = _view.GetFullName;
            if (File.Exists(fullName))
                System.Diagnostics.Process.Start("explorer.exe", fullName);
            else
                _messageService.ShowError("Обраний файл не знайдено");
        }

        void _view_OpenProperties(object sender, EventArgs e)
        {
            string fullName = _view.GetFullName;
            _mannager.ShowFileProperties(fullName);
        }

        void _view_DeleteFile(object sender, EventArgs e)
        {
            string fullName = _view.GetFullName;
            try
            {
                if (_messageService.ShowConfirm("Видалити???", "Ви справді хочете видалити файл" + fullName))
                {
                    _mannager.DeleteFile(fullName);
                    _view.RemoveRow();
                }

            }
            catch (FileNotFoundException ex)
            {
                _messageService.ShowError(ex.Message);
            }

        }

        void _view_ClearResult(object sender, EventArgs e)
        {
            _view.Result(null);
        }

        void _view_ScanClick(object sender, EventArgs e)
        {

            string DirectoryPach = _view.directoryPach;
            bool isExists = _mannager.IsExists(DirectoryPach);

            if (!isExists)
            {
                _messageService.ShowExclamation("Невірний шлях до папки");
                return;

            }

            int algorithm = _view.algorithm;
            string[] fileType = _view.fileType.Split(';');


            double minSize, maxSize;
            int minType, maxType;

            long? minLenght = null, maxLenght = null;

            if (_view.minSizeIsChacked)
            {
                minSize = _view.minSize;
                minType = _view.minSizeType;
                minLenght = byteConverter(minSize, minType);
            }

            if (_view.maxSizeIsChacked)
            {
                maxSize = _view.maxSize;
                maxType = _view.maxSizeType;
                maxLenght = byteConverter(maxSize, maxType);
            }

            Thread thread = new Thread(() => ScanFiles(DirectoryPach, fileType, minLenght, maxLenght, algorithm));
            thread.Start();
            _view.StartTimer(true);
        }
        public void ScanFiles(string pach, string[] type, long? mimS, long? maxL, int alg)
        {

            _mannager.getFs(pach, type, mimS, maxL);
            _mannager.FindDublicate(alg);
            _view.StartTimer(false);//Лише пошук 
            var data = _mannager.GenerateResult(alg);

            _view.Result(data);

            if (data.Rows.Count == 0)
            {
                _messageService.ShowExclamation("Дублікатів не знайдено");
            }

        }

        private long? byteConverter(double size, int type)
        {
            long? bytes = 0;
            switch (type)
            {
                case 0: bytes = (long)size; break;
                case 1: bytes = (long)size * 1024; break;
                case 2: bytes = (long)size * 1048576; break;
                case 3: bytes = (long)size * 1073741824; break;
                default: break;
            }

            return bytes;
        }
    }
}
