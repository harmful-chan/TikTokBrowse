using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio.Models
{

    public enum ActionTypes
    {
        ELEMENT_NOT_FOUND = -2,    // 元素未找到
        ERROR = -1,    // 发生错误
        NONE = 0,    // 初始状态


        BIG_SCREEN_MODE,
        BIG_SCREEN_MODE_FINISH,
        EXIT_BIG_SCREEN_MODE,
        EXIT_BIG_SCREEN_MODE_FINISH,
        EXTRACT_COMMENTS,
        EXTRACT_COMMENTS_FINISH,
        JUMP_WEBSITE,
        JUMP_WEBSITE_FINISH,
        WAIT_READY,
        WAIT_READY_FINISH,

        LOGIN_ACCOUNT,
        LOGIN_ACCOUNT_FINISH,
        NEXT_VIDEO,
        NEXT_VIDEO_FINISH,
        PREVIOUS_VIDEO,
        PREVIOUS_VIDEO_FINISH,
        UPDATE_BLOGGER_DATA,
        UPDATE_BLOGGER_DATA_FINISH,
        UPDATE_PLAY_BAR,
        UPDATE_PLAY_BAR_FINISH,
        RESIZE_BROWSE,
        RESIZE_BROWSE_FINISH,
        VIDEO_LIKE,
        VIDEO_LIKE_FINISH,
        VIDEO_FOLLOW,
        VIDEO_FOLLOW_FINISH,
        PUSH_COMMENT,
        PUSH_COMMENT_FINISH,

        UPLOAD_VIDEO_TIMTOUT,
        UPLOAD_VIDEO_NOT_EXIST,
        UPLOAD_JUMPSITE,
        UPLOAD_JUMPSITE_FINISH,
        UPLOAD_SHOWDIALOG,
        UPLOAD_SHOWDIALOG_FINISH,
        UPLOAD_FILLVIDEO,
        UPLOAD_FILLVIDEO_FINISH,
        UPLOAD_FILLTITLE,
        UPLOAD_FILLTITLE_FINISH,
        UPLOAD_VIDEO,
        UPLOAD_VIDEO_FINISH,
    }
}
