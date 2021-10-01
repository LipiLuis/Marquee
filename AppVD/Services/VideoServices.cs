using AppVD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppVD.Services
{
    public class VideoServices
    {
        public ObservableCollection<Video> GetAllVideos()
        {
            return new ObservableCollection<Video>
            {
                new Video(1, "video1"),
                new Video(2, "video2"),
                new Video(3, "video3"),
                new Video(4, "video4"),
                new Video(5, "video5"),
            };

        }

    }
}
