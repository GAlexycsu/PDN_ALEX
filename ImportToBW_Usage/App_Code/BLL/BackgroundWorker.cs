using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
/// <summary>
/// Summary description for BackgroundWorker
/// </summary>
public class BackgroundWorker
{
	public BackgroundWorker()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    Thread _innerThread = null;

    #region Properties
    /// <summary>
    /// A integer that shows the current progress.
    /// 100 value means the operation is completed.
    /// </summary>
    public int Progress
    {
        get
        {
            return _progress;
        }
    }
    int _progress = 0;

    /// <summary>
    /// A object that you can use it to save the result of the operation.
    /// </summary>
    public object Result
    {
        get
        {
            return _result;
        }
    }
    object _result = null;

    /// <summary>
    /// A boolean variable identifies if current Background Worker is
    /// working or not.
    /// </summary>
    public bool IsRunning
    {
        get
        {
            if (_innerThread != null)
            {
                return _innerThread.IsAlive;
            }
            return false;
        }
    }
    #endregion

    #region Events
    /// <summary>
    /// 
    /// </summary>
    /// <param name="progress">
    /// Report the progress by changing its value
    /// </param>
    /// <param name="_result">
    /// Store value in this varialbe as the result
    /// </param>
    /// <param name="arguments">
    /// The parameters which will be passed to operation method
    /// </param>
    public delegate void DoWorkEventHandler(ref int progress,
        ref object _result, params object[] arguments);

    public event DoWorkEventHandler DoWork;
    #endregion

    /// <summary>
    /// Starts execution of a background operation.
    /// </summary>
    /// <param name="arguments">
    /// The parameters which will be passed to operation method
    /// </param>
    public void RunWorker(params object[] arguments)
    {
        if (DoWork != null)
        {
            _innerThread = new Thread(() =>
            {
                _progress = 0;
                DoWork.Invoke(ref _progress, ref _result, arguments);
                _progress = 100;
            });
            _innerThread.Start();
        }
    }
}