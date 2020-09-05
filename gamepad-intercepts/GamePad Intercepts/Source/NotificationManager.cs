using GamePad_Intercepts.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts
{
    class NotificationManager
    {
        public const int DISPLAY_TIME = 3000;

        private WindowsFormsSynchronizationContext synchronizationContext;
        private System.Threading.Timer timer;
        private Queue<string> messages;
        private string currentStickyNotificationTag = null; // TODO: implement a sticky notification stack of some sort?

        public NotificationForm NotificationForm { get; set; }
        public StickyNotificationForm StickyNotificationForm { get; set; }

        public NotificationManager(WindowsFormsSynchronizationContext synchronizationContext)
        {
            this.synchronizationContext = synchronizationContext;
            this.timer = null;
            this.messages = new Queue<string>();
        }

        public void Notify(string message)
        {
            messages.Enqueue(message);

            // We encapsulate the code in a new thread to make sure the calling thread does not block the form
            new Thread(delegate ()
            {
                ShowNextNotificationMessage();
            }).Start();
        }

        public void NotifySticky(string message, string tag = null)
        {
            // We encapsulate the code in a new thread to make sure the calling thread does not block the form
            new Thread(delegate ()
            {
                currentStickyNotificationTag = tag;
                ShowStickyNotification(message);
            }).Start();
        }

        public void DismissSticky(string tag = null)
        {
            // We encapsulate the code in a new thread to make sure the calling thread does not block the form
            new Thread(delegate ()
            {
                if (tag == null) HideStickyNotification();
                else if (tag == currentStickyNotificationTag) HideStickyNotification();
               
            }).Start();
        }

        private void ShowNextNotificationMessage()
        {
            // Insert retorical comment here...
            if (messages.Count < 1) return;

            // If the timer is active, it will queue the next message at the appropriate time
            if (timer != null) return;

            // The code needs to be run in on the UI thread, else, well...
            synchronizationContext.Post(delegate
            {
                /*
                if (NotificationForm == null || NotificationForm.IsDisposed)
                {
                    NotificationForm = new NotificationForm();
                }
                */
                NotificationForm.ShowWithMessage(messages.Dequeue());

                ScheduleNotificationDismissal();
            }, null);
        }

        private void ScheduleNotificationDismissal()
        {
            if (timer != null) return;

            timer = new System.Threading.Timer((state) =>
            {
                NotificationForm.HideMessage();
                // NotificationForm = null;

                timer.Dispose();
                timer = null;

                if (messages.Count > 0)
                {
                    Thread.Sleep(500); // Giving the user the time to notice the cycling of notifications...
                    ShowNextNotificationMessage();
                }
            }, null, DISPLAY_TIME, Timeout.Infinite);
        }

        private void ShowStickyNotification(string message)
        {
            synchronizationContext.Post(delegate
            {
                StickyNotificationForm.ShowWithMessage(message);
            }, null);
        }

        private void HideStickyNotification()
        {
            synchronizationContext.Post(delegate
            {
                StickyNotificationForm.HideMessage();
            }, null);
        }
    }
}
