using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWPF.ViewModels
{
    public class LoginViewModel:BindableBase
    {
		private string userName;

        private string passWord;

        public string UserName
		{
			get { return userName; }
			set { userName = value; RaisePropertyChanged(); }
		}
		public string PassWord
		{
			get { return passWord; }
			set { passWord = value; RaisePropertyChanged(); }
		}
		public	DelegateCommand LoginCommand { get; private set; }
        public LoginViewModel()
        {
			LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
			if (UserName=="1"&&PassWord=="1")
			{
				HandyControl.Controls.MessageBox.Show("登录成功");
			}
			else
			{
                HandyControl.Controls.MessageBox.Show("失败");
            }
        }
    }
}
