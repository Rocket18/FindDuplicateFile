        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;

        namespace FileDuplicate
        {
        public interface IMessageService
        {
        void ShowMessage(string msg);
        void ShowExclamation(string exc);
        void ShowError(string error);
        bool ShowConfirm(string title,string text);
        }
        public class MessageService:IMessageService
        {
        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg,"Повідомлення",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void ShowExclamation(string exc)
        {
            MessageBox.Show(exc, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool ShowConfirm(string title,string text)
        {
            DialogResult dr = MessageBox.Show(text,title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            return dr == DialogResult.Yes ?  true : false;

            
        }
        }
        }
