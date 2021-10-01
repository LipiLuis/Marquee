using AppVD.Models;
using AppVD.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppVD.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {


        private ObservableCollection<Video> _Videos;
        public ObservableCollection<Video> Videos
        {
            get { return _Videos; }
            set { SetProperty(ref _Videos, value); }
        }

        private ObservableCollection<Mensagem> _Msgs;
        public ObservableCollection<Mensagem> Msgs
        {
            get { return _Msgs; }
            set { SetProperty(ref _Msgs, value); }
        }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            Videos = new ObservableCollection<Video>(new VideoServices().GetAllVideos());
            Msgs = new ObservableCollection<Mensagem>(new MensagenServces().GetAllMsg());
        }
    }
}
