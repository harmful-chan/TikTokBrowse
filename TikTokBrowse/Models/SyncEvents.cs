using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TikTokBrowse.Models
{
    /// <summary>
    /// 日志-同步事件类（用于线程间同步的事件对象）
    /// </summary>
    public class SyncEvents
    {
        private EventWaitHandle _newItemEvent;      // 添加新项
        private EventWaitHandle _exitThreadEvent;   // 退出线程
        private WaitHandle[] _eventArray;           // 线程组

        /// <summary>
        /// 构造器
        /// </summary>
        public SyncEvents()
        {
            _newItemEvent = new AutoResetEvent(false);       // AutoResetEvent对象用来进行线程同步操作(表示线程同步事件在一个等待线程释放后收到信号时自动重置)
            _exitThreadEvent = new ManualResetEvent(false);  // ManualResetEvent是线程用来控制别一个线程的信号事件(表示线程同步事件中，收到信号时，必须手动重置该事件。 此类不能被继承。)
            _eventArray = new WaitHandle[2];
            _eventArray[0] = _newItemEvent;
            _eventArray[1] = _exitThreadEvent;
        }
        /// <summary>
        /// 获取要退出的线程
        /// </summary>
        public EventWaitHandle ExitThreadEvent
        {
            get { return _exitThreadEvent; }
        }
        /// <summary>
        /// 获取新添加的项
        /// </summary>
        public EventWaitHandle NewItemEvent
        {
            get { return _newItemEvent; }
        }
        /// <summary>
        /// 获取线程组
        /// </summary>
        public WaitHandle[] EventArray
        {
            get { return _eventArray; }
        }
    }
}
