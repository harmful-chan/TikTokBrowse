﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Models
{
    public class ViewData : INotifyPropertyChanged
    {
        private string _containerCode;
        public string ContainerCode { get => _containerCode; set { _containerCode = value; NotifyPropertyChanged("ContainerCode"); } }
        
        private string _containerName;
        public string ContainerName { get => _containerName; set { _containerName = value; NotifyPropertyChanged("ContainerName"); } }
        
        private string _containerPosition;
        public string ContainerPosition { get => _containerPosition; set {  _containerPosition = value; NotifyPropertyChanged("ContainerPosition"); } }

        private string _containerStatus;
        public string ContainerStatus { get => _containerStatus; set { _containerStatus = value; NotifyPropertyChanged("ContainerStatus"); } }
        
        private string _bloggerName;
        public string BloggerName { get => _bloggerName; set { _bloggerName = value; NotifyPropertyChanged("BloggerName"); } }
        
        private string _followerNumber;
        public string FollowerNumber { get => _followerNumber; set { _followerNumber = value; NotifyPropertyChanged("FollowerNumber"); } }
        
        private string _videoProgress;
        public string VideoProgress { get => _videoProgress; set { _videoProgress = value; NotifyPropertyChanged("VideoProgress"); } }
        
        private string _likeNumber;
        public string LikeNumber { get => _likeNumber; set { _likeNumber = value; NotifyPropertyChanged("LikeNumber"); } }
        
        private string _commentNumber;
        public string CommentNumber { get => _commentNumber; set { _commentNumber = value; NotifyPropertyChanged("CommentNumber"); } }
        
        private string _shareNumber;
        public string ShareNumber { get => _shareNumber; set { _shareNumber = value; NotifyPropertyChanged("ShareNumber"); } }
        
        private string _behavior;
        public string Behavior { get => _behavior; set { _behavior = value; NotifyPropertyChanged("Behavior"); } }

        private string _tag;
        public string Tag { get => _tag; set { _tag = value; NotifyPropertyChanged("Tag"); } }




        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
