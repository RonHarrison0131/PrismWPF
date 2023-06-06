using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitowVision.Common
{
    public enum LogLevel
    {
        Info = 1,//正常的記錄
        Warn = 2,//警告的记录
        Error = 3//異常的記錄
    }

    public enum LogType
    {
        PLC = 1,//PLC相关
        PLC_Read = 11,//PLC相关
        PLC_Write = 12,//PLC相关
        Camera = 2,//相机相关
        Light = 3,//相机相关
        Net = 4,//网络相关
        SQL = 5,//SQL相关
        AI = 6,//AI算法相关
        AI_Timeout = 61,//AI算法相关
        AI_Error = 62,//AI算法相关
        Algorithm = 7, //传统算法相关
        Algorithm_Timeout = 71, //传统算法相关
        Algorithm_Error = 72, //传统算法相关
        Process = 8,//流程相关
        Message=9//消息相关
    }

    public class Logger
    {
        public static void Debug(object message)
        {
            NLog.Logger logger = LogManager.GetLogger("debug");
            logger.Debug(message);
        }

        public static void Info(object message)
        {
            NLog.Logger logger = LogManager.GetLogger("info");
            logger.Debug(message);
        }

        public static void Warn(object message)
        {
            NLog.Logger logger = LogManager.GetLogger("warn");
            logger.Warn(message);
        }

        public static void Error(object message)
        {
            NLog.Logger logger = LogManager.GetLogger("error");
            logger.Error(message);
        }

        public static void Fatal(object message)
        {
            NLog.Logger logger = LogManager.GetLogger("fatal");
            logger.Fatal(message);
        }

        public static void SaveLog(LogLevel logLevel, LogType logType, string message, Exception exception = null)
        {
            NLog.Logger logger = LogManager.GetLogger("traceMessage");
            string _message = GetMessage(logType,message);
            switch (logLevel)
            {
                case LogLevel.Info:
                    logger.Info(_message);
                    break;
                case LogLevel.Warn:
                    logger.Warn(_message);
                    break;
                case LogLevel.Error:
                    if (exception == null)
                    {
                        logger.Error(_message);
                    }
                    else
                    {
                        logger.Error(exception, _message);
                    }
                    break;
                default:
                    logger.Debug(_message);
                    break;
            }
            
        }

        public static string GetMessage(LogType logType,string message)
        {
            string title = "";
            if (message != null)
            {
                title = message;
            }
            string _message = GetLogTypeString(logType) + title;
            return _message;
        }

        private static string GetLogTypeString(LogType logType)
        {
            string _message = "";
            switch (logType)
            {
                case LogType.PLC:
                    _message += $"【PLC】";
                    break;
                case LogType.PLC_Read:
                    _message += $"【PLC】【Read】";
                    break;
                case LogType.PLC_Write:
                    _message += $"【PLC】【Write】";
                    break;
                case LogType.Camera:
                    _message += $"【相机】";
                    break;
                case LogType.Light:
                    _message += $"【光源】";
                    break;
                case LogType.Net:
                    _message += $"【网络】";
                    break;
                case LogType.SQL:
                    _message += "【数据库】";
                    break;
                case LogType.AI:
                    _message += "【AI算法】";
                    break;
                case LogType.AI_Timeout:
                    _message += "【AI算法】【Timeout】";
                    break;
                case LogType.AI_Error:
                    _message += "【AI算法】【Error】";
                    break;
                case LogType.Algorithm:
                    _message += "【传统算法】";
                    break;
                case LogType.Algorithm_Timeout:
                    _message += "【传统算法】【Timeout】";
                    break;
                case LogType.Algorithm_Error:
                    _message += "【传统算法】【Error】";
                    break;
                case LogType.Process:
                    _message += "【流程】";
                    break;
                case LogType.Message:
                    _message += "【消息】";
                    break;
                default:
                    break;
            }
            return _message;
        }
    }
}
