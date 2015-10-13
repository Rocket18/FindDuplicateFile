﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DuplicateFile.BL;

namespace FileDuplicate
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form = new MainForm();
            MessageService service = new MessageService();
            FileManager manager = new FileManager();
            MainPresenter presenter = new MainPresenter(form,service,manager);

            Application.Run(form);
        }
    }
}
